    class Program
    {
        static readonly Dictionary<SourceLanguage, string> dict = new Dictionary<SourceLanguage, string>()
        {
            [SourceLanguage.Unknown] = "C#",
            [SourceLanguage.VB] = "VB.NET",
            [SourceLanguage.FSharp] = "F#",
            [SourceLanguage.Cpp] = "C++/CLI"
        };
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format($"Entry assembly source language: {dict[Assembly.GetEntryAssembly().GetSourceLanguage()]}"));
            foreach (var t in new[] { typeof(CSClass), typeof(VBClass), typeof(FSClass), typeof(CppClass) })
                Console.WriteLine($"{t.Name} source language: {dict[t.GetSourceLanguage()]}");
        }
    }
		
