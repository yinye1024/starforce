/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework.Network;
using GameMain.Base;

namespace yy.proto
{
    //===================== c2s (开始)  =========================================
    public partial class role_login_c2s : PacketC2S
    {
        public override int Id => PbC2SId.role_login_c2s; 
        
        public override void Clear()
        {
            this.uid = 0;
            this.uname = null;
            this.plat = null;
            this.game_id = null;
            this.svrId = 0;
            this.machine_info = null;
        }
    }
    public partial class role_reconnect_c2s : PacketC2S
    {
        public override int Id => PbC2SId.role_reconnect_c2s; 
        
        public override void Clear()
        {
            this.uid = 0;
            this.svr_id = 0;
            this.client_mid = 0;
            this.svr_mid = 0;
        }
    }
    public partial class reset_gw_mid_c2s : PacketC2S
    {
        public override int Id => PbC2SId.reset_gw_mid_c2s; 
        
        public override void Clear()
        {
            this.mid = 0;
        }
    }
    public partial class create_role_c2s : PacketC2S
    {
        public override int Id => PbC2SId.create_role_c2s; 
        
        public override void Clear()
        {
            this.name = null;
            this.gender = 0;
        }
    }
    public partial class role_logout_c2s : PacketC2S
    {
        public override int Id => PbC2SId.role_logout_c2s; 
        
        public override void Clear()
        {
        }
    }
    //===================== c2s (结束)  =========================================
    
    
    //===================== s2c (开始)  =========================================
    
    public partial class connect_active_s2c : PacketS2C
    {
        public override int Id => PbS2CId.connect_active_s2c; 
        public override void Clear()
        {
            this.result_code = 0;
        }
    }
    public partial class role_login_s2c : PacketS2C
    {
        public override int Id => PbS2CId.role_login_s2c; 
        public override void Clear()
        {
            this.result_code = 0;
            this.main_svr_id = 0;
            this.exist_role = false;
        }
    }
    public partial class role_reconnect_s2c : PacketS2C
    {
        public override int Id => PbS2CId.role_reconnect_s2c; 
        public override void Clear()
        {
            this.need_login = false; 
            this.has_pack = false;
            this.last_client_mid = 0;
        }
    }
    
    public partial class create_role_s2c : PacketS2C
    {
        public override int Id => PbS2CId.create_role_s2c; 
        public override void Clear()
        {
            this.result_code = 0; 
        }
    }
    public partial class role_info_s2c : PacketS2C
    {
        public override int Id => PbS2CId.role_info_s2c; 
        public override void Clear()
        {
            this.role_info = null; 
        }
    }
    public partial class role_logout_s2c : PacketS2C
    {
        public override int Id => PbS2CId.role_logout_s2c; 
        public override void Clear()
        {
            this.code = 0; 
        }
    }
}