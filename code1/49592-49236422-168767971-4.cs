	public static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
	{
        ...
		Console.WriteLine($"Roundtrip Time: {e.Reply.RoundtripTime}");
        ...
	}
