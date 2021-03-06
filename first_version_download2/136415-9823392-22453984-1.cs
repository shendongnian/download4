    private AuthenticationResult Authenticate(string user, string pwhash)
    {
        bool isDone = false;
        AuthenticationResult results = null
        var auth = GetIAuthenticator(); 
        auth.AuthenticationDone += (o, e) => 
        {
            isDone = true;
            results = e;
        };
    
        auth.AuthenticateAsync(user, pwhash);
        long maxWaitTimeSeconds = 10;
        long thresholdMilliseconds = 100;
        int countToWait = 10 * 1000 / 100;
        while (!isDone || countToWait-- > 0)
        {
           Thread.Sleep(thresholdMilliseconds);
        }
        if (countToWait==0 && !isDone)
        {
           // TODO: timeout handling
        }
        
        return results;    
    }
