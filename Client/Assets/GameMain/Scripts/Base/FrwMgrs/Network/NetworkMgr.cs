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
        private INetworkChannel channel;
        public bool IsReady = false;

        public void InitChannel(string ip, int port)
        {
            channel = GameCompMgr.Network.CreateNetworkChannel("Default", ServiceType.Tcp, new NetworkChannelHelper());
            channel.Connect(IPAddress.Parse(ip), port);
        }

        public void Send(PacketC2S packetC2S)
        {
            this.channel.Send(packetC2S);
        }

        public void OnS2C(PacketS2C packetS2C)
        {
            Log.Info("receive msg s2cId:{0}",packetS2C.Id);
        }

        public Type GetS2CTypeById(ushort s2cId)
        {
            return PbS2CId.GetTypeById(s2cId);
        }
    }
}