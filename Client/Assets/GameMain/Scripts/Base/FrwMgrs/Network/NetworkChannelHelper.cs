//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using GameFramework.Network;
using System;
using System.IO;
using System.Text;
using UnityGameFramework.Runtime;

namespace  GameMain.Base
{
    public class NetworkChannelHelper : INetworkChannelHelper
    {
        private INetworkChannel _mNetworkChannel = null;

        /// <summary>
        /// 获取消息包头长度,网络框架底层会用到
        /// </summary>
        public int PacketHeaderLength
        {
            get
            {
                return sizeof(int);
            }
        }

        /// <summary>
        /// 初始化网络频道辅助器。
        /// </summary>
        /// <param name="networkChannel">网络频道。</param>
        public void Initialize(INetworkChannel networkChannel)
        {
           _mNetworkChannel = networkChannel;
           _mNetworkChannel.SetDefaultHandler(RouteS2C);
           
           EventMgr.Instance.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
           EventMgr.Instance.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
           EventMgr.Instance.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
           EventMgr.Instance.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
           EventMgr.Instance.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
        }

        // S2C包业务路由
        private void RouteS2C(object sender, Packet ePacket)
        {
            PacketS2C packetS2C = (PacketS2C)ePacket;
      
            NetworkMgr.Instance.OnS2C(packetS2C);
            if (packetS2C != null)
            {
                // 这里也可以不手动调Release，框架会在下一针自动 release Packet
                // 因为 Packet 是个EventArgs,分发完到这里，后一帧就会走EventArgs 的 release
                // PacketPool.ReleaseS2CPacket(packetS2C);
            }
            
        }


        /// <summary>
        /// 关闭并清理网络频道辅助器。
        /// </summary>
        public void Shutdown()
        {
           EventMgr.Instance.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
           EventMgr.Instance.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
           EventMgr.Instance.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
           EventMgr.Instance.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
           EventMgr.Instance.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);

            _mNetworkChannel = null;
        }

        /// <summary>
        /// 准备进行连接。
        /// </summary>
        public void PrepareForConnecting()
        {
            _mNetworkChannel.Socket.ReceiveBufferSize = 1024 * 64;
            _mNetworkChannel.Socket.SendBufferSize = 1024 * 64;
        }

        /// <summary>
        /// 发送心跳消息包。
        /// </summary>
        /// <returns>是否发送心跳消息包成功。</returns>
        public bool SendHeartBeat()
        {
            // var avatarHeartBeatC2S = PacketUtils.GetC2SPacket<avatar_heart_beat_c2s>();
            // // 客户端的服务器时间
            // avatarHeartBeatC2S.svr_time = 1010000;
            // m_NetworkChannel.Send(avatarHeartBeatC2S);
            return true;
        }

        /// <summary>
        /// 序列化消息包。
        /// </summary>
        /// <typeparam name="T">消息包类型。</typeparam>
        /// <param name="packetC2S">要序列化的消息包。</param>
        /// <param name="destination">要序列化的目标流。</param>
        /// <returns>是否序列化成功。</returns>
        public bool Serialize<T>(T packetC2S, Stream destination) where T : Packet
        {
            byte[] packetBytes  = PacketUtils.Encode(packetC2S);
            // 这里的packetC2S 在业务层必须是调用 PacketUtils.GetC2SPacket<T>() 获取
            PacketPool.ReleaseC2SPacket(packetC2S as PacketC2S);
            int length = packetBytes.Length;

            // Use BinaryWriter to write the formatted [length(4位) + id(2位) + packet] to the destination stream
            using (BinaryWriter writer = new BinaryWriter(destination, Encoding.UTF8, true))
            {
                // Write length + 2 (for the c2sId),
                // 小端转网络
                writer.Write(NetworkUtils.HostToNetworkOrder_Int32(length + 2));
                
                // Write ID
                // 小端转网络
                UInt16 c2sId = (UInt16)packetC2S.Id;
                writer.Write(NetworkUtils.HostToNetworkOrder_UInt16(c2sId));
                
                // Write packet bytes
                writer.Write(packetBytes);
                
                Log.Info("send msg with length:{0} ",length + 2);
            }

            // Flush the stream
            destination.Flush();
            return true;
        }


        /// <summary>
        /// 反序列化消息包头。
        /// </summary>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包头。</returns>
        public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
        {
            // 注意：此函数并不在主线程调用！

            // 使用 BinaryReader 从流中读取数据
            using (BinaryReader reader = new BinaryReader(source, Encoding.UTF8, true))
            {
                // 从流中先读取包长度
                Int32 length = NetworkUtils.NetworkToHostOrder_Int32(reader.ReadBytes(4));
                
              
                // 手动赋值PacketHeader
                var header = PacketPool.AcqPacketS2CHeader();
                header.PacketLength = length;
                customErrorData = header;
                return header;
            }
        }


        /// <summary>
        /// 反序列化消息包。
        /// </summary>
        /// <param name="packetHeader">消息包头。</param>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包。</returns>
        public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
        {
            int protoPacketLength = packetHeader.PacketLength-2;// 2 是刚刚读取的s2cId的长度
            PacketPool.ReleasePacketS2CHeader(packetHeader as PacketS2CHeader);
            // 注意：此函数并不在主线程调用！
            customErrorData = null;
            
            // 使用 BinaryReader 从流中读取数据
            Packet packet = null;
            using (BinaryReader reader = new BinaryReader(source, Encoding.UTF8, true))
            {
                
                // 读取 S2CId
                UInt16 s2cId =  NetworkUtils.NetworkToHostOrder_UInt16(reader.ReadBytes(2));
                Type protoType = NetworkMgr.Instance.GetS2CTypeById(s2cId);
                if (protoType != null)
                {
                    
                    byte[] buffer = new byte[protoPacketLength];
                    int bytesRead = source.Read(buffer, 0, protoPacketLength);
                    if(bytesRead == protoPacketLength)
                    {
                        packet = PacketPool.AcqS2CPacket(protoType);
                        PacketUtils.Merge(packet,buffer);
                    }
                    else
                    {
                        Log.Warning("Bytes Read wrong for s2cId id '{0}'.", s2cId);
                    }
                }
                else
                {
                    Log.Warning("ProtoType not found for s2cId id '{0}'.", s2cId);
                }
                return packet;
            }
            
        }

        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkConnectedEventArgs ne = (UnityGameFramework.Runtime.NetworkConnectedEventArgs)e;
            if (ne.NetworkChannel != _mNetworkChannel)
            {
                return;
            }
            
            Log.Info("Network channel '{0}' connected, local address '{1}', remote address '{2}'.", ne.NetworkChannel.Name, ne.NetworkChannel.Socket.LocalEndPoint.ToString(), ne.NetworkChannel.Socket.RemoteEndPoint.ToString());
            NetworkMgr.Instance.IsReady = true;
        }

        private void OnNetworkClosed(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkClosedEventArgs ne = (UnityGameFramework.Runtime.NetworkClosedEventArgs)e;
            if (ne.NetworkChannel != _mNetworkChannel)
            {
                return;
            }
            NetworkMgr.Instance.IsReady = false;
            Log.Info("Network channel '{0}' closed.", ne.NetworkChannel.Name);
        }

        private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs ne = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;
            if (ne.NetworkChannel != _mNetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' miss heart beat '{1}' times.", ne.NetworkChannel.Name, ne.MissCount.ToString());

            if (ne.MissCount < 2)
            {
                return;
            }
            NetworkMgr.Instance.IsReady = false;
            ne.NetworkChannel.Close();
        }

        private void OnNetworkError(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
            if (ne.NetworkChannel != _mNetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' error, error code is '{1}', error message is '{2}'.", ne.NetworkChannel.Name, ne.ErrorCode.ToString(), ne.ErrorMessage);
            NetworkMgr.Instance.IsReady = false;
            ne.NetworkChannel.Close();
        }

        private void OnNetworkCustomError(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkCustomErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkCustomErrorEventArgs)e;
            if (ne.NetworkChannel != _mNetworkChannel)
            {
                return;
            }
        }
    }
}
