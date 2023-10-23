/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Net.Sockets;

namespace TcpTestSvr;

public static class SenderS2C
{
    
    public static async Task SendMessageAsync(NetworkStream stream, ushort s2cId, byte[] message)
    {
        byte[] lengthBytes = NetworkUtils.HostToNetworkOrder_Int32(message.Length + 2); // +2 for id
        // Array.Reverse(lengthBytes); // Convert to BigEndian

        byte[] idBytes = NetworkUtils.HostToNetworkOrder_UInt16(s2cId);
        // Array.Reverse(idBytes); // Convert to BigEndian

        await stream.WriteAsync(lengthBytes, 0, lengthBytes.Length);
        await stream.WriteAsync(idBytes, 0, idBytes.Length);
        await stream.WriteAsync(message, 0, message.Length);
    }

   
}