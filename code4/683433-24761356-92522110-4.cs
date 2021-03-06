    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IWindowManager windowManager;
        public ShellViewModel()
        {
            this.windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.Height = 600;
            settings.Width = 300;
            settings.SizeToContent = SizeToContent.Manual;
            this.windowManager.ShowWindow(new LameViewModel(), null, settings);
        }
    }
