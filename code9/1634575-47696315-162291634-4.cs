     class AlternateColorConverter : IValueConverter
    {
        private static int idx_;
        private static int idx(int offset)
        {
            idx_ = ((idx_ + 1) % offset);
            return idx_;
        }
        public static Color GetColorFromHex(string hexString)
        {
            Color x = (Color)XamlBindingHelper.ConvertValue(typeof(Color), hexString);
            return x;
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
           int param = System.Convert.ToInt32(parameter);
           return new SolidColorBrush(ColorUtils.GetColorFromHex((idx(param) == 0) ? "#F24C27" : "#FBBA42"));
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
