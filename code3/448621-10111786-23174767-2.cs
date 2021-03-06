    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (parameter == null || parameter.Equals(String.Empty)) parameter = "{0}";
            string path = String.Format((string) parameter, value);
            return new BitmapImage(new Uri(path));
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
