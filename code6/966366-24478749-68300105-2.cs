    static async Task AsyncExample()
    {
        Task<string> task = DownloadPageAsync();
        string result = await task;
        WriteToFile(result, someFileName);
    }
    public static void Main(string[] args)
    {
        var task = AsyncExample();
        
        task.ContinueWith( t => { }).Wait();
    }
