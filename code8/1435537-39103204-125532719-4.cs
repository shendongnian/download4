    private int NextKey = 0;
    public int AddToMyDictionary(string value)
    {
        int currentKey = NextKey++;
        MyDictionary.Add(currentKey, value);
        
        return currentKey;
    }
    public RemoveFromMyDictionary(int key)
    {
         MyDictionary.Remove(key);
         NextKey = key;
    }
