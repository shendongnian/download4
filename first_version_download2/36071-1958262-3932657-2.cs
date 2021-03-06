      public enum FileType
      {
         Url,
         Unc,
         Drive,
         Other,
      }
      public static FileType DetermineType(string file)
      {
         System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(file, "^(?<unc>\\\\)|(?<drive>[a-zA-Z]:\\.*)|(?<url>http://).*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
         if (matches.Count > 0)
         {
            if (matches[0].Groups["unc"].Value.Length > 0) return FileType.Unc;
            if (matches[0].Groups["drive"].Value.Length > 0) return FileType.Drive;
            if (matches[0].Groups["url"].Value.Length > 0) return FileType.Url;
         }
         return FileType.Other;
      }
