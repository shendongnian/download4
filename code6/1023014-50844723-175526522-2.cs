    using (ScpClient client = new ScpClient(host, username, password))
    {
        client.Connect();
        using (Stream localFile = File.Create(localFilePath))
        {
             sftp.Download(remoteFilePath, localFile);
        }
    }
