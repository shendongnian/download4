    public class ViewModel : INotifyPropertyChanged
    {
         public ViewModel()
         {
              _yourCollection = new ObservableCollection<yourType>();
              //Now Items can be added, via code behind, or UI !
         }
    }
