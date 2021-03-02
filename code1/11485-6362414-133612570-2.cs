    public App()
    {
        AppDomain.CurrentDomain.AssemblyResolve +=new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    
    System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll","");
    
        dllName = dllName.Replace(".", "_");
    
        if (dllName.EndsWith("_resources")) return null;
    
        System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
    
        byte[] bytes = (byte[])rm.GetObject(dllName);
    
        return System.Reflection.Assembly.Load(bytes);
    }
