    using System.IO;
    using System.Drawing;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    public class ImagingBitmapInfo
    {
        public ImagingBitmapInfo()
        {
            this.Metadata = new MetadataInfo();
        }
        public SizeF ImageSize { get; set; }
        public SizeF Dpi { get; set; }
        public Size PixelSize { get; set; }
        public List<PixelFormatChannelMask> Masks { get; set; }
        public int BitsPerPixel { get; set; }
        public PixelFormat PixelFormat { get; set; }
        public bool HasPalette { get; set; }
        public BitmapPalette Palette { get; set; }
        public bool IsGrayScale {
            get { return ChackIfGrayScale(); }
        }
        public bool HasAnimation { get; set; }
        public MetadataInfo Metadata { get; set; }
        private bool ChackIfGrayScale()
        {
            if (this.PixelFormat == PixelFormats.Gray32Float ||
                this.PixelFormat == PixelFormats.Gray16 ||
                this.PixelFormat == PixelFormats.Gray8 || 
                this.PixelFormat == PixelFormats.Gray4 || 
                this.PixelFormat == PixelFormats.Gray2)
                return true;
            else if (this.PixelFormat == PixelFormats.Indexed8 ||
                     this.PixelFormat == PixelFormats.Indexed4 ||
                     this.PixelFormat == PixelFormats.Indexed2)
            {
                List<System.Windows.Media.Color> IndexedColors = this.Palette.Colors.ToList();
                return IndexedColors.All(rgb => (rgb.R == rgb.G && rgb.G == rgb.B && rgb.B == rgb.R));
            }
                    
            return false;
        }
        public void SetMetadataNonSupported()
        {
            this.Metadata.ApplicationName = @"N/A";
            this.Metadata.Author = new List<string>() { @"N/A" };
            this.Metadata.CameraManufacturer = @"N/A";
            this.Metadata.CameraModel = @"N/A";
            this.Metadata.Comment = @"N/A";
            this.Metadata.Copyright = @"N/A";
            this.Metadata.DateTaken = @"N/A";
            this.Metadata.Subject = @"N/A";
            this.Metadata.Title = @"N/A";
        }
        public class MetadataInfo
        {
            public string ApplicationName { get; set; }
            public List<string> Author { get; set; }
            public string Copyright { get; set; }
            public string CameraManufacturer { get; set; }
            public string CameraModel { get; set; }
            public string Comment { get; set; }
            public string Format { get; set; }
            public string Subject { get; set; }
            public string Title { get; set; }
            public string DateTaken { get; set; }
            public int Rating { get; set; }
        }
    }
        
    public static ImagingBitmapInfo BitmapPixelFormat(string FileName)
    {
        using (FileStream stream = File.Open(FileName, FileMode.Open, 
                                             FileAccess.Read, FileShare.None))
        {
            return BitmapPixelFormat(stream);
        }
    }
    public static ImagingBitmapInfo BitmapPixelFormat(FileStream stream)
    {
        ImagingBitmapInfo imageInfo = new ImagingBitmapInfo();
        var bitmapDecoder = BitmapDecoder.Create(stream, 
                                                 BitmapCreateOptions.PreservePixelFormat, 
                                                 BitmapCacheOption.Default);
        BitmapSource bitmapSource = bitmapDecoder.Frames[0];
        ImageMetadata imageMetadata = bitmapSource.Metadata;
        BitmapMetadata bitmapMetadata = (BitmapMetadata)bitmapSource.Metadata;
        try
        {
            imageInfo.PixelFormat = bitmapSource.Format;
            imageInfo.HasPalette = (bitmapSource.Palette != null) ? true : false;
            imageInfo.Palette = bitmapSource.Palette;
            imageInfo.ImageSize = new SizeF((float)bitmapSource.Height, (float)bitmapSource.Width);
            imageInfo.Dpi = new SizeF((float)bitmapSource.DpiX, (float)bitmapSource.DpiY);
            imageInfo.PixelSize = new Size(bitmapSource.PixelHeight, bitmapSource.PixelWidth);
            imageInfo.Masks = bitmapSource.Format.Masks.ToList();
            imageInfo.BitsPerPixel = bitmapSource.Format.BitsPerPixel;
            imageInfo.HasAnimation = bitmapSource.HasAnimatedProperties;
            imageInfo.Metadata.Format = bitmapMetadata.Format;
            //If not supported, Catch and set imageInfo.SetMetadataNonSupported()
            imageInfo.Metadata.ApplicationName = bitmapMetadata.ApplicationName;
            imageInfo.Metadata.Author = (bitmapMetadata.Author != null) 
                                      ? bitmapMetadata.Author.ToList<string>() 
                                      : null;
            imageInfo.Metadata.CameraModel = bitmapMetadata.CameraModel;
            imageInfo.Metadata.CameraManufacturer = bitmapMetadata.CameraManufacturer;
            imageInfo.Metadata.CameraModel = bitmapMetadata.Comment;
            imageInfo.Metadata.Copyright = bitmapMetadata.Copyright;
            imageInfo.Metadata.Subject = bitmapMetadata.Subject;
            imageInfo.Metadata.Title = bitmapMetadata.Title;
            imageInfo.Metadata.Rating = bitmapMetadata.Rating;
            imageInfo.Metadata.Format = bitmapMetadata.Format;
            imageInfo.Metadata.DateTaken = bitmapMetadata.DateTaken;
        }
        catch (System.NotSupportedException)
        { imageInfo.SetMetadataNonSupported(); }
        catch (System.Exception ex) { /* Log ex */ throw ex; }
        return imageInfo;
    }
