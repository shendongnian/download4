    public class ViewModelListStuff : SomeBaseClass
    {
        private string name;
        public ICommand PreviewMouseLeftButtonDownCommand { get; set; }
        public ICommand KeyUpCommand { get; set; }
        public String Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged();
            }
        }
        // I would have exposed your cvsSomething here as a property instead, whatever it is.
        public ViewModelListStuff() 
        {
            InitStuff();
        }
        public void InitStuff()
        {
            PreviewMouseLeftButtonDownCommand = new RelayCommand<MouseButtonEventArgs>(PreviewMouseLeftButtonDown);
            KeyUpCommandnCommand = new RelayCommand<KeyEventArgs>(KeyUp);
        }
        private void KeyUp(KeyEventArgs e)
        {
            // Do your stuff here...
        }
        private void PreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            // Do your stuff heere
        }
    }
