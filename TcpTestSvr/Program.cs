using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ProtoBuf;
using TcpTestSvr;

class Program
{
    static async Task Main()
    {
        // Test.DoTest();
        await TcpSvr.StartSvr();
    }
    
}
