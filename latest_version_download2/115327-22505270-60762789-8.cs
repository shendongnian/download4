     public MainPage()
            {
                InitializeComponent();
                this.Loaded += MainPage_Loaded;
            }
     
            void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                viewModel.LoadData();
                DataContext = viewModel;
            }
