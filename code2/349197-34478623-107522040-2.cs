    private async Task<IEnumerable<Assembly>> GetAssemblyListAsync()
    {
        var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
        List<Assembly> assemblies = new List<Assembly>();
        foreach (StorageFile file in await folder.GetFilesAsync())
        {
            if (file.FileType == ".dll" || file.FileType == ".exe")
            {
                var fileName = file.Name.Substring(0, file.Name.Length - file.FileType.Length);
                Assembly assembly = Assembly.Load(new AssemblyName() { Name = fileName });
                assemblies.Add(assembly);
            }
        }
    
        return assemblies;
    }
