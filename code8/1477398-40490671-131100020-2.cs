    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false); //Exception
        Run();
    }
    public static void Run()
    {
        Application.Run(new Form1());
    }
