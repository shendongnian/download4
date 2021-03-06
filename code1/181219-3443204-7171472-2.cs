    public string GetMACAddress() {
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        
        string MACAddress = String.Empty;
        
        foreach (ManagementObject mo in moc) {
            if (MACAddress == String.Empty) { // only return MAC Address from first card
                if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
            }
            mo.Dispose();
        }
        return MACAddress;
    }
