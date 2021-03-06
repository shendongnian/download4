    private IEnumerable<int> constructSetFromBits(int i)
    {
        int n = 0;
        for (; i != 0; i /= 2)
        {
            if ((i & 1) != 0)
                yield return n;
            n++;
        }
    }
    List<string> allValues = new List<string>()
            { "A1", "A2", "A3", "B1", "B2", "C1" };
    private IEnumerable<List<string>> produceEnumeration()
    {
        for (int i = 0; i < (1 << allValues.Count); i++)
        {
            yield return
                constructSetFromBits(i).Select(n => allValues[n]).ToList();
        }
    }
    public List<List<string>> produceList()
    {
        return produceEnumeration().ToList();
    }
    
