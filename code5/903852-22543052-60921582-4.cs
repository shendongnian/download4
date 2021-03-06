    public struct CompletedTask
    {
        public readonly Task Task;
        public CompletedTask(Task task) { this.Task = task; }
    }
    public static class TaskExt
    {
        public static Task<CompletedTask> Convert(this Task @this)
        {
            return @this.ContinueWith(t =>
            {
                // propagate exceptions without wrapping
                t.GetAwaiter().GetResult();
                // return the original task
                return new CompletedTask(t);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
