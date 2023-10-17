/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;
using GameFramework.Network;

namespace GameMain.Base
{
    public class PacketS2CHeader:IPacketHeader,IReference
    {
        public int PacketLength { get; set; }
        public void Clear()
        {
            this.PacketLength = 0;
        }
    }
}