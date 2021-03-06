    public class SynchronizeHourHandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue)
            {
                return (DateTime.Now.Minute / 2);
            }
            else
            {
                if ((int)value > 59)
                {
                    value = (int)value - 60;
                }
                return ((int)value / 2);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
