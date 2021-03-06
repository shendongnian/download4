    public abstract class ViewModelBase : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	public virtual ICommand NavigateCommand => new RelayCommand(Navigate, o=> CanExecute());
    
    	//You'll override this method in your class 
    	protected virtual bool CanExecute()
    	{
    		return true;
    	}
    	
    	//You'll override this method in your class
    	protected virtual void Navigate(object param)
    	{
    
    	}
    }
