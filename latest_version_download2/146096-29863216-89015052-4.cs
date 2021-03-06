    foreach (var prop in typeof(ConfigFile).GetProperties())
    {
        var attr = prop.GetCustomAttributes(false)
                       .OfType<ConfigFileFieldAttribute>()
                       .FirstOrDefault();
        string val;
        if (attr != null && testDict.TryGetValue(attr.Name, out val))
            prop.SetValue(cfgFile, val);
    }
