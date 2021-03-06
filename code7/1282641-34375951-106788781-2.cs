    public async Task RunTasks()
    {
        var tasks = new List<Func<Task>>
        {
            DoWork,
            //...
        };
        await Task.WhenAll(tasks.AsParallel().Select(task => task()));
        
        //Run the other tasks
    }
