/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using ProtoBuf;

namespace TcpTestSvr;

public class ProtoUtils
{
    // var serializedMsg = Encode(myMessage);
    public static byte[] Encode<T>(T msgPacket) where T : IExtensible
    {
        using (MemoryStream memory = new MemoryStream())
        {
            Serializer.Serialize(memory, msgPacket);
            return memory.ToArray();
        }
    }
    
    // byte[] myBytes = /* 获取字节数组 */;
    // var myMessage = Decode(typeof(MyMessage), myBytes) as MyMessage;
    public static T Decode<T>(byte[] bytes)
    {
        Type protoType = typeof(T);
        using (MemoryStream memory = new MemoryStream(bytes))
        {
            return (T)Serializer.Deserialize(protoType, memory);
        }
    }
}