    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        
            this.DataContext = new MARK()
            {
                Name = "UserName"
            };
    
        }
