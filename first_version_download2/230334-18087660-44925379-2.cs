    using (var myStream = new System.IO.MemoryStream())
    {
        using (var sw = new System.IO.StreamWriter(myStream))
        {
            sw.Write(value);
        }
        using (var stream = new MemoryStream(myStream.ToArray(), writable:false)
        {
           hash = sha256.ComputeHash(myStream);
        }
    }
