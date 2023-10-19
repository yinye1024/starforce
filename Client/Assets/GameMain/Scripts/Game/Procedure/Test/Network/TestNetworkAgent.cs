/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;
using GameMain.Base;
using UnityGameFramework.Runtime;
using yy.proto;

namespace GameMain.Test
{
    public class TestNetworkAgent:INetworkAgent
    {
        public static TestNetworkAgent NewInstance()
        {
            return new TestNetworkAgent();
        }

        public void RouteS2C(PacketS2C packetS2C)
        {
            UInt16 s2dId = (UInt16)packetS2C.Id;
            switch (s2dId)
            {
                case PbS2CId.role_login_s2c:
                    HandleLoginS2C((role_login_s2c)packetS2C);
                    break;
                case PbS2CId.create_role_s2c:
                    HandleLoginS2C((create_role_s2c)packetS2C);
                    break;
                default:
                    break;
            }
            
        }

        private void HandleLoginS2C(role_login_s2c roleLoginS2C)
        {
            if (!roleLoginS2C.exist_role)
            {
                TestNetworkMgr.Instance.SendCreate();
            }

        }
        private void HandleLoginS2C(create_role_s2c createRoleS2C)
        {
            if (createRoleS2C.result_code == 0)
            {
               Log.Info("create success !");
            }

        }
    }
}