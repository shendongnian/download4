        public static T GetResultSafe<T>(this Task<T> task)
        {
            if (SynchronizationContext.Current == null)
                return task.Result;
	        if (task.IsCompleted)
		        return task.Result;
            task.ConfigureAwait(false);
			var tcs = new TaskCompletionSource<T>();
			task.ContinueWith(t =>
            {
                var ex = t.Exception;
                if (ex != null)
                    tcs.SetException(ex);
                else
                    tcs.SetResult(t.Result);
            });
            return tcs.Task.Result;
        }
