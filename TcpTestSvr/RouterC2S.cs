/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using yy.proto;

namespace TcpTestSvr;

public class RouterC2S
{
    public static (ushort s2cId, byte[] s2dMsg) route(ushort c2sId,byte[] packetBytes)
    {
        ushort s2cId = 0;
        byte[] s2dMsgBytes = new byte[] { };
        switch (c2sId)
        {
            case 1:
                (s2cId, s2dMsgBytes)  = HandleLoginC2S(packetBytes);
                break;
            case 4:
                (s2cId, s2dMsgBytes)  = HandleCreateC2S(packetBytes);
                break;
            default:
                break;
        }
        return  (s2cId, s2dMsgBytes);
    }

    private static (ushort s2cId, byte[] s2dMsg) HandleLoginC2S(byte[] packetBytes)
    {
        role_login_c2s loginC2S = ProtoUtils.Decode<role_login_c2s>(packetBytes);
        Console.WriteLine($"Received loginC2S with uid {loginC2S.uid} and name {loginC2S.uname}");

        role_login_s2c loginS2C = new role_login_s2c();
        loginS2C.exist_role = false;
        loginS2C.result_code = 0;
        loginS2C.main_svr_id = 1;
        byte[] respBytes = ProtoUtils.Encode(loginS2C);
        ushort loginS2CId = 1; 
        return (loginS2CId,respBytes);
    }
    private static (ushort s2cId, byte[] s2dMsg) HandleCreateC2S(byte[] packetBytes)
    {
        create_role_c2s createRoleC2S = ProtoUtils.Decode<create_role_c2s>(packetBytes);
        Console.WriteLine($"Received create_role_c2s with name {createRoleC2S.name} and gender {createRoleC2S.gender}");

        create_role_s2c createRoleS2C = new create_role_s2c();
        createRoleS2C.result_code = 0;
        byte[] respBytes = ProtoUtils.Encode(createRoleS2C);
        ushort createRoleS2CId = 4; 
        return (createRoleS2CId,respBytes);
    }
}