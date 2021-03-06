    private async void button_Click(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
        await renderTargetBitmap.RenderAsync(ImageHolder);
        var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
        var pixels = pixelBuffer.ToArray();
        var displayInformation = DisplayInformation.GetForCurrentView();
        var picker = new FileSavePicker();
        picker.FileTypeChoices.Add("JPEG Image", new string[] { ".jpg" });
        StorageFile file = await picker.PickSaveFileAsync();
        using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, displayInformation.RawDpiX, displayInformation.RawDpiY, pixels);
            await encoder.FlushAsync();
        }
    }
