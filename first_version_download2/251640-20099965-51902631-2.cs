    [Flags()]
    public enum DisplayDeviceStateFlags : int
    {
        /// <summary>The device is part of the desktop.</summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>The device is part of the desktop.</summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>The device is removable; it cannot be the primary display.</summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct DISPLAY_DEVICE 
    {
          [MarshalAs(UnmanagedType.U4)]
          public int cb;
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
          public string DeviceName;
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
          public string DeviceString;
          [MarshalAs(UnmanagedType.U4)]
          public DisplayDeviceStateFlags StateFlags;
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
          public string DeviceID;
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
          public string DeviceKey;
    }
    
    
    [DllImport("user32.dll")]
    static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);
    
    void Main()
    {
    	DISPLAY_DEVICE d=new DISPLAY_DEVICE();
        d.cb=Marshal.SizeOf(d);
        try {
            for (uint id=0; EnumDisplayDevices(null, id, ref d, 0); id++) {
                Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", id, d.DeviceName, d.DeviceString, d.StateFlags, d.DeviceID));
    			
    			EnumDisplayDevices(d.DeviceName, 0, ref d, 1);
                Console.WriteLine(String.Format("    {0}, {1}, {2}, {3}, {4}", id, d.DeviceName, d.DeviceString, d.StateFlags, d.DeviceID));						  
                d.cb=Marshal.SizeOf(d);
            }
        } catch (Exception ex) {
            Console.WriteLine(String.Format("{0}",ex.ToString()));
        }
    }
