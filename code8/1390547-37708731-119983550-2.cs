    List<string> filecontents = File.ReadAllLines("abc.txt").ToList<string();
    for (int i = 0; i < filecontents.Count; i++)
       {
           if (filecontents[i].Contains("Test Results : Fail"))
           {                          
               string error = filecontents[i + 1];
           }
       }
