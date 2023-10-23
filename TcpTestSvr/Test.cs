/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Diagnostics;
using ProtoBuf;
using yy.proto;

namespace TcpTestSvr;

public class Test
{
    // required int32 uid = 1;
    // required string uname = 2;
    // required string plat = 3;
    // required string game_id = 4;
    // required int32 svrId = 6;
    // optional p_machineInfo machine_info = 7;
    public static void DoTest()
    {
        role_login_c2s roleLoginC2s = new role_login_c2s()
        {
            uid = 32424823,
            uname = "dklion",
            game_id = "start force",
            svrId = 2,
            plat = "steam"
        };
        

        byte[] encoded = ProtoUtils.Encode(roleLoginC2s);

        role_login_c2s roleLoginC2s_1 = ProtoUtils.Decode<role_login_c2s>( encoded);
        
        Console.WriteLine(roleLoginC2s_1.uid);

    }
}