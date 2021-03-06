    // .NET 4.0 friendly
    public static IEnumerable<string> EnumerateFiles(string path, params string[] filters)
    {
        return filters.Length == 0
            ? Directory.EnumerateFiles(path)
            : filters.SelectMany(filter => Directory.EnumerateFiles(path, filter));
    }
    // .NET 3.5 friendly
    public static IEnumerable<string> GetFiles(string path, params string[] filters)
    {
        return filters.Length == 0
            ? Directory.GetFiles(path)
            : filters.SelectMany(filter => Directory.GetFiles(path, filter));
    }
