    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;
    
        #region Constructors
    
        public DelegateCommand(Action<object> execute)
            : this(execute, null) { }
    
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
    
        #endregion
    
        #region ICommand Members
    
        public event EventHandler CanExecuteChanged;
    
        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }
    
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }
    
        public void NotifyCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    
        #endregion
    
    }
