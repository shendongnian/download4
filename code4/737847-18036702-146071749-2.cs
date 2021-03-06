    class Program : System.Windows.Forms.Form
    {
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.Run(new Program());
        }
        const int WM_DEVICECHANGE = 0x0219;
        const int NB_MOUNTED_VOLUMES = 26;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    ShowChange();
                    break;
            }
            base.WndProc(ref m);
        }
        private String[] m_oldMount;
        public Program()
        {
            m_oldMount = new String[NB_MOUNTED_VOLUMES];
            for (int i = 0; i < NB_MOUNTED_VOLUMES; i++)
                m_oldMount[i] = String.Empty;
        }
        private void ShowChange()
        {
            String[] currentMount = GetMountList();
            for (int i = 0; i < NB_MOUNTED_VOLUMES; i++)
            {
                if (currentMount[i] != m_oldMount[i])
                {
                    if (String.IsNullOrEmpty(currentMount[i]))
                    {
                        Console.WriteLine("{0} : Dismount on {1}: => {2}",
                            DateTime.Now,
                            (char)('A' + i),
                            m_oldMount[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0} : Mount on {1}: => {2}",
                            DateTime.Now,
                            (char)('A' + i),
                            currentMount[i]);
                    }
                }
            }
            m_oldMount = currentMount;
        }
        private String[] GetMountList()
        {
            uint size = (uint)Marshal.SizeOf(typeof(MOUNT_LIST_STRUCT));
            IntPtr buffer = Marshal.AllocHGlobal((int)size);
            uint bytesReturned;
            IntPtr _hdev = CreateFile("\\\\.\\TrueCrypt", FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            bool bResult = DeviceIoControl(_hdev, TC_IOCTL_GET_MOUNTED_VOLUMES, buffer, size, buffer, size, out bytesReturned, IntPtr.Zero);
            MOUNT_LIST_STRUCT mount = new MOUNT_LIST_STRUCT();
            Marshal.PtrToStructure(buffer, mount);
            Marshal.FreeHGlobal(buffer);
            return mount.wszVolume.Select(m => m.ToString()).ToArray();
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        class MOUNT_LIST_STRUCT
        {
            public readonly UInt32 ulMountedDrives; /* Bitfield of all mounted drive letters */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
            public readonly MOUNT_LIST_STRUCT_VOLUME_NAME[] wszVolume;  /* Volume names of mounted volumes */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
            public readonly UInt64[] diskLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
            public readonly int[] ea;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
            public readonly int[] volumeType;   /* Volume type (e.g. PROP_VOL_TYPE_OUTER, PROP_VOL_TYPE_OUTER_VOL_WRITE_PREVENTED, etc.) */
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct MOUNT_LIST_STRUCT_VOLUME_NAME
        {
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I2, SizeConst = 260)]
            public readonly char[] wszVolume;   /* Volume names of mounted volumes */
            public override string ToString()
            {
                return (new String(wszVolume)).TrimEnd('\0');
            }
        }
        public static int CTL_CODE(int DeviceType, int Function, int Method, int Access)
        {
            return (((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2)
              | (Method));
        }
        private static readonly uint TC_IOCTL_GET_MOUNTED_VOLUMES = (uint)CTL_CODE(0x00000022, 0x800 + (6), 0, 0);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode,
        IntPtr lpInBuffer, uint nInBufferSize,
        IntPtr lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
             [MarshalAs(UnmanagedType.LPTStr)] string filename,
             [MarshalAs(UnmanagedType.U4)] FileAccess access,
             [MarshalAs(UnmanagedType.U4)] FileShare share,
             IntPtr securityAttributes, // optional SECURITY_ATTRIBUTES struct or IntPtr.Zero
             [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
             [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
             IntPtr templateFile);
    }
