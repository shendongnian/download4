    public class ShellViewModel
    {
      private BaseViewModel _currentPage{get;set;}
      Public BaseViewModel CurrentPage{
          get{return _currentPage;}
          set{_currentPage = value; OnPropertyChanged();}
      }
      public ShellViewModel
      {
        CurrentPage = new MyViewModel();
      }
    }
