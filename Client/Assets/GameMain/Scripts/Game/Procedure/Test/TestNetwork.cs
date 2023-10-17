/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;
using yy.proto;

namespace GameMain.Game
{
    public class TestNetwork : Singleton<TestNetwork>
    {
        private bool isWaitS2C = false;
        
        public void OnEnter()
        {
            string ip = "127.0.0.1";
            int port = 12345;
            NetworkMgr.Instance.InitChannel(ip,port);
        }

        public void OnUpdate()
        {
            if (NetworkMgr.Instance.IsReady && !isWaitS2C)
            {
                role_login_c2s loginC2S = PacketPool.AcqC2SPacket<role_login_c2s>();
                loginC2S.uid = 10001;
                loginC2S.uname = "jelly fish";
                loginC2S.plat = "tx";
                loginC2S.svrId = 1;
                loginC2S.game_id = "StartCraftWar";
                loginC2S.machine_info = null;
                NetworkMgr.Instance.Send(loginC2S);
                isWaitS2C = true;
            }

        }
    }
}