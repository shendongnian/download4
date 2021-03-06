    public class MyViewModel
    {
        public MyCommand ButtonClick { get; set; }
    
        public MyViewModel()
        {
            ButtonClick = new MyCommand();
            ButtonClick.CanExecuteFunc = obj => true;
            ButtonClick.ExecuteFunc = ButtonClickFunc;
        }
    
        public void ButtonClickFunc(object parameter)
        {
            // Do stuff here 
        }
    
    }
    
    public class MyCommand : ICommand 
    {
        public event EventHandler CanExecuteChanged;
        public Predicate<object> CanExecuteFunc { get; set; }
        public Action<object> ExecuteFunc { get; set; }
    
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }
        
        public void Execute(object parameter)
        {
            ExecuteFunc(parameter);
        }
    }
