    public class UserAccountsStatusHandler : INotifyPropertyChanged, ICommand
    {
        private UserAccountActions userAccountAction;
        public UserAccountActions UserAccountAction
        {
            get { return userAccountAction; }
            set
            {
                userAccountAction = value;
                IsSaveEnabled = (userAccountAction == UserAccountActions.None) ? false : true;
                OnPropertyChanged("UserAccountAction");
                // Refresh the CanExecute method.
                OnCanExecuteChanged();
            }
        }
        private bool isSavedEnabled;
        public bool IsSaveEnabled { get { return isSavedEnabled; } set { isSavedEnabled = value; OnPropertyChanged("IsSaveEnabled"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool CanExecute(object parameter)
        {
            return userAccountAction.SomeActionSelected != null;
        }
        public event EventHandler CanExecuteChanged;
        private void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged!= null)
                this.CanExecuteChanged(this, new EventArgs());
        }
        public void Execute(object parameter)
        {
            // perform save code.
        }
    }
