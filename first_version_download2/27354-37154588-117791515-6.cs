    private void WithRetry(Action action, int timeoutMs = 1000)
    {
        var time = Stopwatch.StartNew();
        while(time.ElapsedMilliseconds < timeoutMs)
        {
            try
            {
                action();
                return;
            }
            catch (IOException e)
            {
                // access error
                if (e.HResult != 0x20)
                    throw;
            }
        }
        throw new Exception("Failed perform action within allotted time.");
    }
