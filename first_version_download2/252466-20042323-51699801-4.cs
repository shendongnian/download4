    class KeyHandle
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private static Int32 WM_KEYDOWN = 0x100;
        private static Int32 WM_KEYUP = 0x101;
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int Msg, System.Windows.Forms.Keys wParam, int lParam);
        
        public static void SendKey(IntPtr hWnd, System.Windows.Forms.Keys key)
        {
            PostMessage(hWnd, WM_KEYUP, key, 0);
        }
        public static void SetForeGround(IntPtr hWnd)
        {
            SetForegroundWindow(hWnd);
        }
    }
