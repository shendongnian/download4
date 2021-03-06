	public static class ConcurrentCoordinationExtension
	{
		private static int _executing = 0;
	
		public static bool TryExecuteSequentially(this Action actionToExecute)
		{
			// compate _executing with zero, if zero, set 1,
			// return original value as result,
			// successfull entry then result is zero, non zero returned, then somebody is executing
			if (Interlocked.CompareExchange(ref _executing, 1, 0) != 0) return false;
			try
			{
				actionToExecute.Invoke();
				return true;
			}
			finally
			{
				Interlocked.Exchange(ref _executing, 0);//
			}
		}
		public static bool TryExecuteSequentially(this Func<bool> actionToExecute)
		{
			// compate _executing with zero, if zero, set 1,
			// return original value as result,
			// successfull entry then result is zero, non zero returned, then somebody is executing
			if (Interlocked.CompareExchange(ref _executing, 1, 0) != 0) return false;
			try
			{
				return actionToExecute.Invoke();
			}
			finally
			{
				Interlocked.Exchange(ref _executing, 0);//
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			DateTime last = DateTime.MinValue;
			Func<bool> operation= () =>
			{
				//calming condition was not meant
				if (DateTime.UtcNow - last < TimeSpan.FromMilliseconds(500)) return false;
				last = DateTime.UtcNow;
				//some stuff you want to process sequentially
				return true;
			};
			operation.TryExecuteSequentially();
		}
	}
