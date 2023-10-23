/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/

using System.Net;
using System.Net.Sockets;
using yy.proto;

namespace TcpTestSvr;

public static class TcpSvr
{
      
    public static async Task StartSvr()
    {
        var listener = new TcpListener(IPAddress.Any, 12345);
        listener.Start();

        Console.WriteLine("Server is running...");
        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client); //异步非租塞，支持多个 client 并发连接
        }
    }
    static async Task HandleClientAsync(TcpClient client)
    {
        using (var stream = client.GetStream())
        {
           
            try
            {
                // 循环接收信息
                while (true)
                {
                    await TcpHandler.HandleC2S(client, stream);
                }
            }
            catch (IOException)
            {
                // 读/写中可能会出现错误，特别是如果客户端意外断开连接。
                Console.WriteLine("Error occurred while handling client.");
            }

            Console.WriteLine("Client disconnected.");
        }
    }

}