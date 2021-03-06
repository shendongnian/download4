    var listener = new TcpListener(IPAddress.Loopback, 8181);
    listener.Start();
    while (true)
    {
        Console.WriteLine("Listening...");
        using (var client = listener.AcceptTcpClient())
        using (var stream = client.GetStream())
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        {
            string line = null;
            string key = "";
            string responseKey = "";
            while (line != "")
            {
                line = reader.ReadLine();
                if (line.StartsWith("Sec-WebSocket-Key:"))
                {
                    key = line.Split(':')[1].Trim();
                }
            }
            if (key != "")
            {
                key = key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
                using (var sha1 = SHA1.Create())
                {
                    responseKey = Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(key)));
                }
            }
            // send handshake to the client
            writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
            writer.WriteLine("Upgrade: WebSocket");
            writer.WriteLine("Connection: Upgrade");
            writer.WriteLine("WebSocket-Origin: http://127.0.0.1");
            writer.WriteLine("WebSocket-Location: ws://localhost:8181/websession");
            if (!String.IsNullOrEmpty(responseKey)) 
                writer.WriteLine("Sec-WebSocket-Accept: " + responseKey);
            writer.WriteLine("");
        }
        Console.WriteLine("Finished");
    }
