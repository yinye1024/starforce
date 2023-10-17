/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;

namespace yy.proto
{
//===================== c2s (开始)  =========================================
    public partial class avatar_heart_beat_c2s : PacketC2S
    {
        public override int Id => PbC2SId.avatar_heart_beat_c2s; 
        
        public override void Clear()
        {
            this.svr_time = 0;
        }
    }
    //===================== c2s (结束)  =========================================
    
    
    //===================== s2c (开始)  =========================================
    
    public partial class avatar_heart_beat_s2c : PacketS2C
    {
        public override int Id => PbS2CId.avatar_heart_beat_s2c; 
        public override void Clear()
        {
            this.svr_time = 0;
        }
    }
    
    //===================== s2c (结束)  =========================================
}