/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;
using System.Net;
using GameFramework.Network;
using UnityGameFramework.Runtime;
using yy.proto;

namespace GameMain.Base
{
    public class NetworkMgr:Singleton<NetworkMgr>
    {
        private INetworkChannel _channel;
        private INetworkAgent _agent;
        public bool IsReady = false;

        public void InitChannel(string ip, int port,INetworkAgent agent)
        {
            this._agent = agent;
            _channel = GameCompMgr.Network.CreateNetworkChannel("Default", ServiceType.Tcp, new NetworkChannelHelper());
            _channel.Connect(IPAddress.Parse(ip), port);
        }

        public void Send(PacketC2S packetC2S)
        {
            this._channel.Send(packetC2S);
        }

        public void RouteS2C(PacketS2C packetS2C)
        {
            Log.Info("receive msg s2cId:{0}",packetS2C.Id);
            this._agent.RouteS2C(packetS2C);
        }

        public Type GetS2CTypeById(ushort s2cId)
        {
            return PbS2CId.GetTypeById(s2cId);
        }

        public bool SendHeartBeat()
        {
            return true;
        }
    }
}