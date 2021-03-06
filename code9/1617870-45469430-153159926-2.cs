    private async Task beginReading()
    {
        byte[] buffer = new byte[1024];
        using (_shutdownToken.Register(() => m_TcpStream.Close()))
        {
            while (!_shutdownToken.IsCancellationRequested)
            {
                try
                {
                    int bytesReceived = 0;
                    if (m_TcpStream.CanRead)
                    {
                        bytesReceived = await m_TcpStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    }
                    else
                    {
                        // in case the stream is not working, wait a little bit
                        await Task.Delay(3000, _shutdownToken);
                    }
                    if (bytesReceived > 0)
                    {
                        for (int i = 0; i < bytesReceived; i++)
                        {
                            bigBuffer.Enqueue(buffer[i]);
                        }
                        _signal.Release();
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception e)
                {
                    LoggingService.Log(e);
                }
            }
        }
    }
    private async Task<int> ReadAsyncWithTimeout(byte[] buffer, int offset, int count)
    {
        int bytesToBeRead = 0;
        if (!m_TcpClient.Connected)
        {
            throw new ObjectDisposedException("Socket is not connected");
        }
        if (bigBuffer.Count > 0)
        {
            bytesToBeRead = bigBuffer.Count < count ? bigBuffer.Count : count;
            for (int i = offset; i < bytesToBeRead; i++)
            {
                buffer[i] = bigBuffer.Dequeue();
            }
            if (_signal.CurrentCount > 0)
                await _signal.WaitAsync(BabelfishConst.TCPIP_READ_TIME_OUT_IN_MS, _shutdownToken).ConfigureAwait(false);
            return bytesToBeRead;
        }
        await _signal.WaitAsync(BabelfishConst.TCPIP_READ_TIME_OUT_IN_MS, _shutdownToken).ConfigureAwait(false);
        // read again in case the semaphore was signaled by an Enqueue
        if (bigBuffer.Count > 0)
        {
            bytesToBeRead = bigBuffer.Count < count ? bigBuffer.Count : count;
            for (int i = offset; i < bytesToBeRead; i++)
            {
                buffer[i] = bigBuffer.Dequeue();
            }
            return bytesToBeRead;
        }
        // This is because the synchronous NetworkStream Read() method throws this exception when it times out
        throw new IOException();
    }
