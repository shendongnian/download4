    public static BitmapSource BitmaSourceFromByteArray(byte[] buffer)
    {
        var bitmap = new BitmapImage();
        using (var stream = new MemoryStream(buffer))
        {
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
        }
        return bitmap;
    }
