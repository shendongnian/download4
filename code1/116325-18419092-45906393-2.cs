    public bool URLExists(string url,int timeout = 5000)
    {
        ...
        webRequest.Timeout = timeout; // miliseconds
        ...
    }
