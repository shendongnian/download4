    public class MainScreenView : View
    {
        private readonly ImageView portraitImageView;
        private readonly ImageView landscapeImageView;
        public MainScreenView(ImageView portrait, ImageView landscape)
            : base(portrait, landscape)
        {
            portraitImageView = portrait;
            landscapeImageView = landscape;
        }
        protected override void OnInitialize() { }
        public ImageView GetPortrait() { return portraitImageView; }
        public ImageView GetLandscape() { return landscapeImageView; }
    }
    public class ImageView : View
    {
        private readonly Image image;
        public ImageView(Image image)
            : base()
        {
            this.image = image;
        }
        protected override void OnInitialize() { image.Show(); }
        public string GetImage() { return image; }
    }
   
