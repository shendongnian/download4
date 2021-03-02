    // create new setting from a base setting:
    var property = new SettingsProperty(Settings.Default.Properties["<baseSetting>"]);
    // create new dynamic setting:
    property.Name = "<dynamicSettingName>";
    Settings.Default.Properties.Add(property);
    // will have the stored value:
    var dynamicSetting = Settings.Default["<dynamicSettingName>"];
