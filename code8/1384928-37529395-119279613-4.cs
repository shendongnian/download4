    public static Task FirstSuccessfulTask(IEnumerable<Task> tasks)
    {
        var taskList = tasks.ToList();
        var tcs = new TaskCompletionSource<bool>();
        int remainingTasks = taskList.Count;
        foreach(var task in taskList)
        {
            task.ContinueWith(t =>
                if(task.Status == TaskStatus.RanToCompletion)
                    tcs.TrySetResult(true));
                else
                    if(Interlocked.Decrement(ref remainingTasks) == 0)
                        tcs.SetException(new AggregateException(
                            tasks.SelectMany(t => t.Exception.InnerExceptions));
        }
        return tcs.Task;
    }
