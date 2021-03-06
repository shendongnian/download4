    static void Main(string[] args)
    {
        TraceSource ts = new TraceSource("MyApplication");
        ts.Switch = new SourceSwitch("MySwitch");
        ts.Switch.Level = SourceLevels.All;
        ts.Listeners.Add(new TextWriterTraceListener(Console.Out));
        for (int i = 0; i < ts.Listeners.Count; i++)
        {
            var listener = ts.Listeners[i];
            listener.WriteLine(string.Format("{0} - MyApplication Info: {1}", DateTime.Now.ToString("HH:mm:ss"), "Hello World"));
            listener.Flush();
        }
        Console.ReadKey();
    }
