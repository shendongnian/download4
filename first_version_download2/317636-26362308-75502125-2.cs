    public Dictionary<string, List<string>> GetCsvFilesGroupedByDate(string csvDirectory)
    {
        var csvFiles = Directory.EnumerateFiles(csvDirectory, "*.csv");
        var groupedByDate = csvFiles.GroupBy(s => s.Substring(0, 8));
        return groupedByDate.ToDictionary(g => g.Key, g => g.ToList());
    }
