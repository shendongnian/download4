    public int GetIntSetting(Settings setting, int nullState)
    {
        var s = GetStringSetting(setting);
        if (string.IsNullOrEmpty(s))
            return nullState;
        return int.TryParse(data, int out parsed) ? parsed : 0;
    }
