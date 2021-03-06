    [ValueConversion(typeof(BitmapSource), typeof(string))]
    public class  BitmapSourceToFileNameConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if (value is BitmapSource bitmapSource)
          return bitmapSource.UriSource.AbsolutePath;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
