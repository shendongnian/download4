                public class MainWindowViewModel        
                {
                    private string _customeName;
            
                    public string CustomerName
                    {
                        get { return _customeName; }
                        set { _customeName = value; }
                    }
            
            
                }
            
                public partial class MainWindow : Window
                {
           
            
                    public MainWindow()
                    {
                        InitializeComponent();
                        this.DataContext = new MainWindowViewModel();
                    }
                }
            }
    
