    string displayname = GetName(MyEnum.SomeType.ToString(), stringResources)
    public string GetName(string key, ResourceManager resourceManager)
    {
        string displayName = resourceManager.GetString(key);
        if (string.IsNullOrEmpty(displayName))
            displayName = key;
        return displayName;
    }
