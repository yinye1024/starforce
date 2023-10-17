/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;
using System.Net;
using GameFramework;
using GameFramework.Network;
using System.IO;
using ProtoBuf;
using ProtoBuf.Meta;

namespace GameMain.Base
{
    public class PacketUtils:Singleton<PacketUtils>
    {

        
        // var serializedMsg = Encode(myMessage);
        public static byte[] Encode<T>(T msgPacket)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Serializer.Serialize(memory, msgPacket);
                return memory.ToArray();
            }
        }
    
        // byte[] myBytes = /* 获取字节数组 */;
        // var myMessage = Decode(typeof(MyMessage), myBytes) as MyMessage;
        public static void Merge(Packet instance, byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                RuntimeTypeModel.Default.Deserialize(memoryStream, instance, instance.GetType());
                // RuntimeTypeModel.Default.Deserialize(memoryStream, (object) null, type);
                // return (Packet)Serializer.NonGeneric.Deserialize(protoType,memoryStream); //将PacketType替换为您的具体类型
            }
        }
        
        
    }
}