    static void Main()
    {
        #if DEBUG
            servicioCR cr = new servicioCR();
            cr.beginProcess();
            Console.WriteLine("Program Running");
            Console.ReadLine();
        #else
        #endif
        //ServiceBase[] ServicesToRun;
        //ServicesToRun = new ServiceBase[] 
        //{ 
        //    new servicioCR() 
        //};
        //ServiceBase.Run(ServicesToRun);
    }
