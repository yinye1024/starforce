/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Net.Sockets;
using TcpTestSvr;

namespace yy.proto;

public static class TcpHandler
{

    public static async Task HandleC2S(TcpClient client, NetworkStream stream)
    {
        // 获取包体总长度
        byte[] lengthBuffer = new byte[4];
        var lengthRead = await ReadExactlyAsync(stream, lengthBuffer, 0, 4);
        if (lengthRead < 4)
        {
            Console.WriteLine("Connection closed for lengthRead error occurred");
            client.Close();
            return;
        }

        int length = NetworkUtils.NetworkToHostOrder_Int32(lengthBuffer);
        // int length = BitConverter.ToInt32(lengthBuffer, 0);

        // 获取c2sId
        byte[] c2sBuffer = new byte[2];
        var c2sRead = await ReadExactlyAsync(stream, c2sBuffer, 0, 2);
        if (c2sRead < 2)
        {
            Console.WriteLine("Connection closed for c2sRead error occurred");
            client.Close();
            return;
        }
        ushort c2sId = NetworkUtils.NetworkToHostOrder_UInt16(c2sBuffer);
        // ushort c2sId = BitConverter.ToUInt16(c2sBuffer, 0);
        Console.WriteLine($"Received message with length {length} and id {c2sId}");

        // 获取proto协议二进制包体
        int packetLength = length - 2;
        byte[] packetBuffer = new byte[packetLength];
        var packetRead = await ReadExactlyAsync(stream, packetBuffer, 0, packetLength);
        if (packetRead < packetLength)
        {
            Console.WriteLine("Connection closed for packetRead error occurred");
            client.Close();
            return;
        }

        // 根据接收到的s2cId和包体，分发到不同的业务进行处理
        (ushort s2cId, byte[] s2cMsg) = RouterC2S.route(c2sId, packetBuffer);
        if (s2cId > 0)
        {
            await SenderS2C.SendMessageAsync(stream, s2cId, s2cMsg);
        }
       
    }

    private static async Task<int> ReadExactlyAsync(NetworkStream stream, byte[] buffer, int offset, int count)
    {
        int bytesRead = 0;
        while (bytesRead < count)
        {
            int read = await stream.ReadAsync(buffer, offset + bytesRead, count - bytesRead);
            if (read == 0) return bytesRead;
            bytesRead += read;
        }
        return bytesRead;
    }
}