    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Sockets;
    namespace ReadAsync
    {
        class Program
        {
            static async Task StartTcpClientAsync(TcpClient tcpClient)
            {
                Console.WriteLine($"    Connection from: [{tcpClient.Client.RemoteEndPoint}]");
                var stream = tcpClient.GetStream();
                var buffer = new byte[1024];
            
                while (true)
                {
                    int x = await stream.ReadAsync(buffer, 0, 1024);
                    Console.WriteLine($"    [{tcpClient.Client.RemoteEndPoint}] " +
                        $"read {x} bytes {System.Text.Encoding.UTF8.GetString(buffer)} "+
                        $"        ^^ On Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                }
            }
            static async Task StartTcpServerAsync()
            {
                var tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, 9999));
                tcpListener.Start();
                            
                while (true)
                {
                    var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    _ = StartTcpClientAsync(tcpClient);
                }
            }
            static async Task Main(string[] args)
            {
                _ = StartTcpServerAsync();
                await Task.Delay(2000);
                _ = RunSenderAsync();
                _ = RunSenderAsync();
                await RunSenderAsync();
            }
            static async Task RunSenderAsync()
            {
                using var tcpClient = new TcpClient("127.0.0.1", 9999);
                Console.WriteLine($"    BiDi source: [{tcpClient.Client.LocalEndPoint}] connected to Pipeline Server");
                using var s = tcpClient.GetStream();
                tcpClient.NoDelay = true;
                for (var i = 65; i < 70; i++)
                {
                    s.Write(BitConverter.GetBytes(i), 0, 1);
                   await Task.Delay(1000);
                }
            }
        }
    }
