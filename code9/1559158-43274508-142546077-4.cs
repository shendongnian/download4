    public class MeFileWatcher
        : FileWatcher
    {
        public MeFileWatcher(string filePath)
            : base(filePath)
        {
        }
        protected override void ProcessLine(string line)
        {
            Console.WriteLine ("NEW LINE ADDED -> {0}", line);
        }
    }
    MeFileWatcher meFileWatcher = new MeFileWatcher("D:\\testData\\meFile.txt");
