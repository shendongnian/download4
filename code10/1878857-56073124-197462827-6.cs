      public class NameConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return (value as Name).LastName;
        }
      }
