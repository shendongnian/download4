    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new TcpClient())
            {
                var server = "smtp.gmail.com";
                var port = 465;
                client.Connect(server, port);
                using (var stream = client.GetStream())
                using (var sslStream = new SslStream(stream))
                {
                    sslStream.AuthenticateAsClient(server);
                    using (var writer = new StreamWriter(sslStream))
                    using (var reader = new StreamReader(sslStream))
                    {
                        writer.WriteLine("EHLO " + server);
                        writer.Flush();
                        Console.WriteLine(reader.ReadLine());
                        // GMail responds with: 220 mx.google.com ESMTP
                    }
                }
            }
        }
    }
