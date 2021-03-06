    Dictionary<string, Dictionary<string,string>> newDictionary = new Dictionary<string, Dictionary<string,string>>();
    foreach (SectionData section  in data.Sections)
    {
        var keyDictionary = new Dictionary<string,string>();
        foreach (KeyData key in section.Keys)
            keyDictionary.Add(key.KeyName.ToString(),key.KeyValue.ToString());
        newDictionary.Add(section.SectionName.ToString(), keyDictionary);
    }
