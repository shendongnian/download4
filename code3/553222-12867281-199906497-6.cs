    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        object result = null;
        var path = value as string;
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            using (var stream = File.OpenRead(path))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                result = image;
            }
        }
        return result;
    }
