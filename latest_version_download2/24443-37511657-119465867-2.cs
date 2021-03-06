    public sealed class GlobalHotkeyRegister : IGlobalHotkeyRegister, IDisposable
    {
        private const int WmHotkey = 0x0312;
        private Application _app;
        private readonly Dictionary<Hotkey, Action> _hotkeyActions;
        public GlobalHotkeyRegister()
        {
            _hotkeyActions = new Dictionary<Hotkey, Action>();
            var startupTcs = new TaskCompletionSource<object>();
            Task.Run(() =>
            {
                ComponentDispatcher.ThreadPreprocessMessage += OnThreadPreProcessMessage;
                _app = new Application();
                _app.Startup += (s, e) => startupTcs.SetResult(null);
                _app.Run();
            });
            startupTcs.Task.Wait();
        }
        public void Add(Hotkey hotkey, Action action)
        {
            _hotkeyActions.Add(hotkey, action);
            var keyModifier = (int) hotkey.KeyModifier;
            var key = KeyInterop.VirtualKeyFromKey(hotkey.Key);
            _app.Dispatcher.Invoke(() =>
            {
                if (!RegisterHotKey(IntPtr.Zero, hotkey.GetHashCode(), keyModifier, key))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            });       
        }
        public void Remove(Hotkey hotkey)
        {
            _hotkeyActions.Remove(hotkey);
            _app.Dispatcher.Invoke(() =>
            {
                if (!UnregisterHotKey(IntPtr.Zero, hotkey.GetHashCode()))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            });
        }
        private void OnThreadPreProcessMessage(ref MSG msg, ref bool handled)
        {
            if (msg.message != WmHotkey)
                return;
            var key = KeyInterop.KeyFromVirtualKey(((int) msg.lParam >> 16) & 0xFFFF);
            var keyModifier = (KeyModifier) ((int) msg.lParam & 0xFFFF);
            var hotKey = new Hotkey(keyModifier, key);
            _hotkeyActions[hotKey]();
        }
        public void Dispose()
        {
            _app.Dispatcher.InvokeShutdown();
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
    public class Hotkey
    {
        public Hotkey(KeyModifier keyModifier, Key key)
        {
            KeyModifier = keyModifier;
            Key = key;
        }
        public KeyModifier KeyModifier { get; }
        public Key Key { get; }
        #region ToString(), Equals() and GetHashcode() overrides
    }
    [Flags]
    public enum KeyModifier
    {
        None = 0x0000,
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008,
        NoRepeat = 0x4000
    }
