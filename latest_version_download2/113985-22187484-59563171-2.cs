    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);
    
        private const int WM_SETTEXT = 0x000C;
    
        ...
    
        public void SetTextOnRemoteTextBox(string text)
        {
            SendMessage(textBox1.Handle, WM_SETTEXT, (IntPtr)text.Length, text);
        }
