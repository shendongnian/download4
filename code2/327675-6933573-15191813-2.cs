    public class UserData : INotifyPropertyChanged
    {
       /* sample code : missing the implentation for INotifyProperty changed */
       private bool Value = true;
       public bool Value
       { 
          get{ return _value;} 
          set{ _value= value;
               RaiseNotification("Value");
             }; }
    }
