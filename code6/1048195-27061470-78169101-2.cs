    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        Object[] ret = new Object[targetTypes.Length];
        for(Int32 i = 0; i < targetType.Length; i++)
        {
            // Propagate a copy of value to each Binding
            ret[i] = value.ToString();
        }
    }
