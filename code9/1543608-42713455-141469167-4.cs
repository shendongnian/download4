     public interface IWindowView
     {
            IUserControlKeeper ViewModel { get; set; }
     }
     public interface IUserControlKeeper 
     {
            UserControl Control { get; set; }
     }
    
     public partial class YourWindow : IViewWindow
     {
            public ModalWindow()
            {
                InitializeComponent();
            }
    
            public IUserControlKeeper ViewModel
            {
                get
                {
                    return (IUserControlKeeper)DataContext;
                }
    
                set
                {
                    DataContext = value;
                }
            }
      }
