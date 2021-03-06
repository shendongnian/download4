    using Xamarin.Forms;
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    
    namespace MyNamespace
    {
        public static class PropertyStorage
        {
            private const string KeyMyPropertyX = "myPropertyX";
    
            public static string MyPropertyX
            {
                get { return AppSettings.GetValueOrDefault(nameof(MyPropertyX), string.Empty, KeyMyPropertyX); }
                set { AppSettings.AddOrUpdateValue(nameof(MyPropertyX), value, KeyMyPropertyX); }
            }
    
            private static ISettings AppSettings
            {
                get { return CrossSettings.Current; }
            }
        }
    }
