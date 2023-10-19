/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;

namespace yy.proto
{
    public class PbC2SId
    {
        // login
        public const UInt16 role_login_c2s = 1;
        public const UInt16 role_reconnect_c2s = 2;
        public const UInt16 reset_gw_mid_c2s = 3;
        public const UInt16 create_role_c2s = 4;
        public const UInt16 role_logout_c2s = 5;
        
        //avatar
        public const UInt16 avatar_heart_beat_c2s = 6;
        
    }
    public class PbS2CId
    {
        // login
        public const UInt16 connect_active_s2c = 0;
        public const UInt16 role_login_s2c = 1;
        public const UInt16 role_reconnect_s2c = 2;
        public const UInt16 create_role_s2c = 4;
        public const UInt16 role_info_s2c = 5;
        public const UInt16 role_logout_s2c = 6;
        
        //avatar
        public const UInt16 avatar_heart_beat_s2c = 7;

        public static Type GetTypeById(UInt16 s2cId)
        {
            Type protoType = s2cId switch
            {
                connect_active_s2c => typeof(connect_active_s2c),
                role_login_s2c => typeof(role_login_s2c),
                role_reconnect_s2c => typeof(role_reconnect_s2c),
                create_role_s2c => typeof(create_role_s2c),
                role_info_s2c => typeof(role_info_s2c),
                role_logout_s2c => typeof(role_logout_s2c),
                _ => null,
            };
            return protoType;
        }
    }
    
    
}