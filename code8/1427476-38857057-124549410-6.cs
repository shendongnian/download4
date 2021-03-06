    public void QuoteEnclosingCSV(string fileNamePath)
    {
        var stringBuilder = new StringBuilder();
        foreach (var line in File.ReadAllLines(fileNamePath))
        {
            stringBuilder.AppendLine(string.Format("\"{0}\"", string.Join("\",\"", line.Split(','))));
        }
        //  I don't know what string.Format() is meant to do here; I'm guessing your guess is 
        //  as good as mine, so I'm eliminating it. 
        //File.WriteAllText(string.Format(fileNamePath, Path.GetDirectoryName(fileNamePath)), stringBuilder.ToString());
        File.WriteAllText(fileNamePath, stringBuilder.ToString());
    }
