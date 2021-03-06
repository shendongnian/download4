    using System.Drawing.Imaging;
    public partial class ImagePeelEffect : Form
    {
    string WorkingDirectory = @"C:\temp\";
    public ImagePeelEffect()
    {
       InitializeComponent();
    }
    
    private void ImagePeelEffect_Load(object sender, EventArgs e)
    {
        picBefore.Image = Image.FromFile(WorkingDirectory + "\\before.jpg");    
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        //create a image object containing the photograph to add page peel effect
    	Image imgPhoto = Image.FromFile(WorkingDirectory + "\\before.jpg");
    	int phWidth = imgPhoto.Width;
    	int phHeight = imgPhoto.Height;
    
    	//create a Bitmap the Size of the original photograph
    	Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
    
    	bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
    
    	//load the Bitmap into a Graphics object 
    	Graphics grPhoto = Graphics.FromImage(bmPhoto);
    
        //create a image object containing the PagePeel
        Image imgPagePeel = new Bitmap(WorkingDirectory + "\\PagePeel.bmp");
        int ppWidth = imgPagePeel.Width;
        int ppHeight = imgPagePeel.Height;
    
        //Set the rendering quality for this Graphics object
        grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    
        //Draws the photo Image object at original size to the graphics object.
        grPhoto.DrawImage(
            imgPhoto,                               // Photo Image object
            new Rectangle(0, 0, phWidth, phHeight), // Rectangle structure
            0,                                      // x-coordinate of the portion of the source image to draw. 
            0,                                      // y-coordinate of the portion of the source image to draw. 
            phWidth,                                // Width of the portion of the source image to draw. 
            phHeight,                               // Height of the portion of the source image to draw. 
            GraphicsUnit.Pixel);                    // Units of measure 
    
        //The first step in manipulating the PagePeel image is to replace 
        //the background color with one that is transparent (Alpha=0, R=0, G=0, B=0)
        //to do this we will use a Colormap and define ImageAttributes with a RemapTable
        ImageAttributes imageAttributes = new ImageAttributes();
        ColorMap colorMap = new ColorMap();
    
        //My PagePeel was defined with a background of 100% Green this will
        //be the color we search for and replace with transparency
        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
    
        //Set the Remap Table with the old and new color map
        ColorMap[] remapTable = { colorMap };
        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
    
    
        //For this example we will place the PagePeel in the bottom right
        //hand corner of the photograph
        int xPosOfPp = phWidth - ppWidth;
        int yPosOfPp = phHeight - ppHeight + 1;
    
        grPhoto.DrawImage(imgPagePeel,
            new Rectangle(xPosOfPp, yPosOfPp, ppWidth, ppHeight),  //Set the detination Position
            0,                  // x-coordinate of the portion of the source image to draw. 
            0,                  // y-coordinate of the portion of the source image to draw. 
            ppWidth,            // PagePeel Width
            ppHeight,		    // PagePeel Height
            GraphicsUnit.Pixel, // Unit of measurment
            imageAttributes);   //ImageAttributes Object
    
        //Replace the original photgraphs bitmap with the new Bitmap
        imgPhoto = bmPhoto;
        grPhoto.Dispose();
    
        //save new image to file system.
        imgPhoto.Save(WorkingDirectory + "\\after.jpg", ImageFormat.Jpeg);
        imgPhoto.Dispose();
        imgPagePeel.Dispose();
        //Show the After image
        picAfter.Image = Image.FromFile(WorkingDirectory + "\\after.jpg");
    
    }
