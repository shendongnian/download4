    string[] results = theserows.Split('\n');
    resultSet = new NameValueCollection[Count];
    for(int i = 0; i < results.Count && i < Count; i++)
    {
        string s = results[i];
        resultSet[i] = new NameValueCollection();
        string[] result = s.Split(',');
        foreach (string col in result) // As pointed by other users, this should be result insead of results, again bad var name choice
        {
            string[] kv = col.Split('=');
            if(kv.Length >= 2)
            resultSet[i].Add(kv[0], kv[1]);
        }
     }
