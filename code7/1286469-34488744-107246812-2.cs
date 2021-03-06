    public static bool PingHost(string nameOrAddress)
    {
        bool pingable = false;
        Ping pinger = new Ping();
        try
        {
            PingReply reply = pinger.Send(nameOrAddress);
            pingable = reply.Status == IPStatus.Success;
        }
        catch (PingException)
        {
            // Discard PingExceptions and return false;
        }
        return pingable;
    }
