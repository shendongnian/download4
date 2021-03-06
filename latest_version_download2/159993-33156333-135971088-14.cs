    /// <summary>
    /// UInt Enumeration with Flags that specify which information is requested.
    /// </summary>
    [Flags()]
    public enum SHGSI : UInt32
    {
    
    	/// <summary>
    	/// The szPath and iIcon members of the SHSTOCKICONINFO structure receive the path and icon index of the requested icon, in a format suitable for passing to the ExtractIcon function. The numerical value of this flag is zero, so you always get the icon location regardless of other flags.
    	/// </summary>
    	SHGSI_ICONLOCATION = 0,
    
    	/// <summary>
    	/// The hIcon member of the SHSTOCKICONINFO structure receives a handle to the specified icon.
    	/// </summary>
    	SHGSI_ICON = 0x100,
    
    	/// <summary>
    	/// The iSysImageImage member of the SHSTOCKICONINFO structure receives the index of the specified icon in the system imagelist.
    	/// </summary>
    	SHGSI_SYSICONINDEX = 0x4000,
    
    	/// <summary>
    	/// Modifies the SHGSI_ICON value by causing the function to add the link overlay to the file's icon.
    	/// </summary>
    	SHGSI_LINKOVERLAY = 0x8000,
    
    	/// <summary>
    	/// Modifies the SHGSI_ICON value by causing the function to blend the icon with the system highlight color.
    	/// </summary>
    	SHGSI_SELECTED = 0x10000,
    
    	/// <summary>
    	/// Modifies the SHGSI_ICON value by causing the function to retrieve the large version of the icon, as specified by the SM_CXICON and SM_CYICON system metrics.
    	/// </summary>
    	SHGSI_LARGEICON = 0x0,
    
    	/// <summary>
    	/// Modifies the SHGSI_ICON value by causing the function to retrieve the small version of the icon, as specified by the SM_CXSMICON and SM_CYSMICON system metrics.
    	/// </summary>
    	SHGSI_SMALLICON = 0x1,
    
    	/// <summary>
    	/// Modifies the SHGSI_LARGEICON or SHGSI_SMALLICON values by causing the function to retrieve the Shell-sized icons rather than the sizes specified by the system metrics.
    	/// </summary>
    	SHGSI_SHELLICONSIZE = 0x4
    
    }
