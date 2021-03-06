    private static Cache Cache;
    public void AddData(string data)
    {
        //Do a database call to add the data
        //This will force clients to requery the source when GetData is called again.
        Cache.Remove("test");  
    }
    public string GetData()
    {
        //Attempt to get the data from cache
        string data = Cache.Get("test") as string;
        //Check to see if we got it from cache
        if (data == null)
        {
            //We didn't get it from cache, so load it from 
            // wherever it comes from.
            data = "From database or something";
            //Put it in cache for the next user
            Cache["test"] = data;
        }
        return data;
    }
