    private static void ParseFilesTypes()
    {
        string sampleFilePath = @"log.txt";
        string[] lines = File.ReadAllLines(@"log.txt", Encoding.GetEncoding("windows-1252"));
        foreach (string str in lines)
        {
            int r = str.IndexOf("<li>");
            if (r >= 0)
            {
                int i = str.IndexOf(" —", r + 1);
                if (i >= 0)
                {
    
                    int c = str.IndexOf(" —", i);
                    if (c >= 0)
                    {
                        i++;
                        int startIndex = r + "<li>".Length;
                        int length = i - startIndex - 1;
                        string result = str.Substring(r + "<li>".Length, length);
                        MessageBox.Show(result);
                    }
                }
            }
        }
    }
