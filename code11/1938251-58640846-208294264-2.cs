    public class RepositionWindowCommand : ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                 window.Left = SystemParameters.PrimaryScreenWidth - window.Width;
                 window.Top = 0;
            }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
    }
