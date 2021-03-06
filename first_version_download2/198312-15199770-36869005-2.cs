    private bool IsAssemblyDebugBuild(string filepath)
    {
        return IsAssemblyDebugBuild(Assembly.LoadFile(Path.GetFullPath(filepath)));
    }
     
    private bool IsAssemblyDebugBuild(Assembly assembly)
    {
        foreach (var attribute in assembly.GetCustomAttributes(false))
        {
            var debuggableAttribute = attribute as DebuggableAttribute;
            if(debuggableAttribute != null)
            {
                return debuggableAttribute.IsJITTrackingEnabled;
            }
        }
        return false;
    }
