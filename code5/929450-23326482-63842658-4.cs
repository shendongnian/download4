    static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                try
                {
                    //args[0] exsists, so a file gets opened
                    //args[0] is the file path
                    Application.Run(new Form1(args[0]));   
                }
                catch
                {
                    //args[0] doesn't exsist
                    Application.Run(new Form1());
                }
            }
