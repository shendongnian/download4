    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var btn = (Button) sender;
    
                Type newType = Type.GetType("WpfApplication1."+ btn.Name, true, true);
    
                object o = Activator.CreateInstance(newType);
                StkPanel.Children.Add(UIElement o);
            }
        }
    }
