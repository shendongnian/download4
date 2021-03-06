    private List<int> GetIndexForKeyWord(string content,string key)
    {
        int index = 0;
        List<int> indexes=new List<int>();
        while (index < content.Length && index >= 0)
        {
            index = content.IndexOf(key, index);
            if (index+key.Length==content.Length||index >= 0 && !char.IsLetter(content[index + key.Length]))
            {
                indexes.Add(index);
            }
            if(index!=-1)
                index++;
        }
        return indexes;
    }
