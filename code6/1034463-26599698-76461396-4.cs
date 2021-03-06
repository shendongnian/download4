    Dictionary<string, WordInfo> concordanceDictionary = new Dictionary<string, WordInfo>();
    string myText = File.ReadAllText("C:\Text.txt").ToLower();
    string[] words = SplitWords(myText);
    foreach (var word in words)
    {
        int i = 1;
        if (!concordanceDictionary.ContainsKey(word))
        {
            concordanceDictionary.Add(word, new WordInfo(word, i));
        }
        else
        {
            concordanceDictionary[word].WordCount++;
            concordanceDictionary[word].LineNumbers.Add(i);
        }
        i++;
    }
