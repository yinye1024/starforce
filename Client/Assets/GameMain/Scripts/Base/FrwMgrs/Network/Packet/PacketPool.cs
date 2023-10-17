/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;
using GameFramework;

namespace GameMain.Base
{
    public static class PacketPool
    {
        
        public static T AcqC2SPacket<T>() where T:PacketC2S
        {
            Type packetType = typeof(T);
            return (T)ReferencePool.Acquire(packetType);
        }
        public static void ReleaseC2SPacket(PacketC2S packet)
        {
            ReferencePool.Release(packet);
        }
        public static PacketS2C AcqS2CPacket(Type packetType) 
        {
            return (PacketS2C)ReferencePool.Acquire(packetType);
        }
        public static void ReleaseS2CPacket(PacketS2C packet)
        {
            ReferencePool.Release(packet);
        }
        public static PacketS2CHeader AcqPacketS2CHeader() 
        {
            return ReferencePool.Acquire<PacketS2CHeader>();
        }
        public static void ReleasePacketS2CHeader(PacketS2CHeader packet)
        {
            ReferencePool.Release(packet);
        }
    }
}