    // Load the image (probably from your stream)
    Image image = Image.FromFile( imagePath );
    using (Graphics g = Graphics.FromImage(image))
    {
    // Modify the image using g here... 
    // Create a brush with an alpha value and use the g.FillRectangle function
    SolidBrush shadowBrush = new SolidBrush(Red);
    g.DrawRectangle(shadowBrush, /*RectanglePointsHere*/);
    }
    image.Save( imageNewPath );
