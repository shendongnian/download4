    public bool TryOpenRegKey(RegistryKey regKey, string subKey = default(string))
    {
      try
      {
        if (string.IsNullOrWhiteSpace(subKey))
          ScanSubKey(regKey);
        else
          ScanSubKey(regKey.OpenSubKey(subKey));
        return true;
      }
      catch(Exception ex)
      {
        Debug.WriteLine("The following error occurred opening a registry key: " + ex.Message);
        return false;
      }
    }
