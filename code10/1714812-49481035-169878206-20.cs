    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    public class ImagingBitmapInfo
    {
        FramesInfo framesInfo;
        public ImagingBitmapInfo()
        {
            this.framesInfo = new FramesInfo();
            this.Metadata = new MetadataInfo();
            this.Metadata.ApplicationName = string.Empty;
            this.Metadata.Author = new List<string>() {  };
            this.Metadata.CameraManufacturer = string.Empty;
            this.Metadata.CameraModel = string.Empty;
            this.Metadata.Comment = string.Empty;
            this.Metadata.Copyright = string.Empty;
            this.Metadata.DateTaken = string.Empty;
            this.Metadata.Subject = string.Empty;
            this.Metadata.Title = string.Empty;
        }
        public Size ImageSize { get; set; }
        public Size Dpi { get; set; }
        public Size PixelSize { get; set; }
        public List<PixelFormatChannelMask> Masks { get; set; }
        public int BitsPerPixel { get; set; }
        public PixelFormat PixelFormat { get; set; }
        public string ImageType { get; set; }
        public bool HasPalette { get; set; }
        public BitmapPalette Palette { get; set; }
        public bool HasThumbnail { get; set; }
        public BitmapImage Thumbnail { get; set; }
        public int Frames { get; set; }
        public FramesInfo FramesContent
        { get { return this.framesInfo; } }
        public bool IsMetadataSuppported { get; set; }
        public MetadataInfo Metadata { get; set; }
        public bool HasAnimation { get; set; }
        public enum DeepScanOptions : int
        {
            Default = 0,
            Skip,
            Force
        }
        public enum GrayScaleInfo : int
        {
            None = 0,
            Partial, 
            GrayScale,
            Undefined
        }
        public System.Drawing.Bitmap ThumbnailToBitmap()
        {
            if (this.Thumbnail == null)
                return null;
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                                         this.Thumbnail.DecodePixelWidth, 
                                         this.Thumbnail.DecodePixelHeight))
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(this.Thumbnail));
                encoder.Save(outStream);
                return (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(outStream);
            }
        }
        public void FrameSourceoAddRange(BitmapFrame[] bitmapFrames)
        {
            if (bitmapFrames == null) return;
            this.framesInfo.Frames.AddRange(bitmapFrames.Select(bf => new FramesInfo.Frame() 
            { 
                FrameSize = new Size(bf.PixelWidth, bf.PixelHeight),
                FrameDpi = new Size(bf.DpiX, bf.DpiY),
                PixelFormat = bf.Format,
                IsGrayScaleFrame = CheckIfGrayScale(bf.Format, bf.Palette, DeepScanOptions.Force),
                IsBlackWhiteFrame = (bf.Format == PixelFormats.BlackWhite)
            }));
            this.framesInfo.Frames.Where(f => (!f.IsGrayScaleFrame & !f.IsBlackWhiteFrame))
                                  .All(f => f.IsColorFrame = true);
        }
        public GrayScaleInfo IsGrayScaleFrames()
        {
            if (this.framesInfo.Frames.Count == 0)
                return GrayScaleInfo.Undefined;
            if (this.framesInfo.FramesGrayscaleNumber > 0)
                return (this.framesInfo.FramesGrayscaleNumber == this.framesInfo.FramesTotalNumber)
                        ? GrayScaleInfo.GrayScale 
                        : GrayScaleInfo.Partial;
            return GrayScaleInfo.None;
        }
        public bool IsGrayScale(DeepScanOptions DeepScan) {
            return CheckIfGrayScale(this.PixelFormat, this.Palette, DeepScan);
        }
        private bool CheckIfGrayScale(PixelFormat pixelFormat, BitmapPalette palette, DeepScanOptions DeepScan)
        {
            if (pixelFormat == PixelFormats.Gray32Float ||
                pixelFormat == PixelFormats.Gray16 ||
                pixelFormat == PixelFormats.Gray8 ||
                pixelFormat == PixelFormats.Gray4 ||
                pixelFormat == PixelFormats.Gray2)
                if (DeepScan != DeepScanOptions.Force) return true;
                else if (pixelFormat == PixelFormats.Indexed8 ||
                         pixelFormat == PixelFormats.Indexed4 ||
                         pixelFormat == PixelFormats.Indexed2)
                    DeepScan = (DeepScan != DeepScanOptions.Skip) ? DeepScanOptions.Force : DeepScan;
            if ((DeepScan != DeepScanOptions.Skip) & palette != null)
            {
                List<Color> IndexedColors = palette.Colors.ToList();
                return IndexedColors.All(rgb => (rgb.R == rgb.G && rgb.G == rgb.B && rgb.B == rgb.R));
            }
            return false;
        }
        public class FramesInfo
        {
            public FramesInfo()
            {
                this.Frames = new List<Frame>();
            }
            public int FramesTotalNumber
            {
                get { return (this.Frames != null) ? this.Frames.Count() : 0; }
                private set { }
            }
            public int FramesColorNumber
            {
                get { return (this.Frames != null) ? this.Frames 
                                  .Where(f => f.IsColorFrame == true)
                                  .Count() : 0; }
                private set { }
            }
            public int FramesGrayscaleNumber
            {
                get {return (this.Frames != null) ? this.Frames
                                 .Where(f => f.IsGrayScaleFrame == true)
                                 .Count() : 0; }
                private set { }
            }
            public int FramesBlackWhiteNumber
            {
                get { return (this.Frames != null) ? this.Frames
                                  .Where(f => f.IsBlackWhiteFrame == true)
                                  .Count() : 0; }
                private set { }
            }
            public List<Frame> Frames { get; private set; }
            internal class Frame
            {
                public Size FrameSize { get; set; }
                public Size FrameDpi { get; set; }
                public PixelFormat PixelFormat { get; set; }
                public bool IsColorFrame { get; set; }
                public bool IsGrayScaleFrame { get; set; }
                public bool IsBlackWhiteFrame { get; set; }
            }
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
        using (FileStream stream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
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
            imageInfo.Frames = bitmapDecoder.Frames.Count();
            if (imageInfo.Frames > 0)
                imageInfo.FrameSourceoAddRange(bitmapDecoder.Frames.ToArray());
                    
            imageInfo.ImageType = bitmapMetadata.Format.ToUpperInvariant();
            imageInfo.PixelFormat = bitmapSource.Format;
            imageInfo.HasPalette = (bitmapSource.Palette != null) ? true : false;
            imageInfo.Palette = bitmapSource.Palette;
            imageInfo.ImageSize = new Size((float)bitmapSource.Height, (float)bitmapSource.Width);
            imageInfo.Dpi = new Size((float)bitmapSource.DpiX, (float)bitmapSource.DpiY);
            imageInfo.PixelSize = new Size(bitmapSource.PixelHeight, bitmapSource.PixelWidth);
            imageInfo.Masks = bitmapSource.Format.Masks.ToList();
            imageInfo.BitsPerPixel = bitmapSource.Format.BitsPerPixel;
            imageInfo.HasAnimation = bitmapDecoder.CodecInfo.SupportsAnimation;
            imageInfo.HasThumbnail = bitmapDecoder.Thumbnail != null;
            if (imageInfo.HasThumbnail)
                imageInfo.Thumbnail = (BitmapImage)bitmapDecoder.Thumbnail.CloneCurrentValue();
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
        { imageInfo.IsMetadataSuppported = false; }
        catch (System.Exception ex) { /* Log ex */ throw ex; }
        return imageInfo;
    }
