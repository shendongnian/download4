	static Task RunProcessAsync(string fileName)
	{
		// there is no non-generic TaskCompletionSource
		var tcs = new TaskCompletionSource<bool>();
		var process = new Process
		{
			StartInfo = { FileName = fileName },
			EnableRaisingEvents = true
		};
		process.Exited += (sender, args) =>
		{
			tcs.SetResult(process.ExitCode == 0);
			process.Dispose();
		};
		process.Start();
		return tcs.Task;
	}
