    public class IconConverter : System.Windows.Forms.AxHost
        {
            private IconConverter()
                : base(string.Empty)
            {
            }
    
            public static stdole.IPictureDisp GetIPictureDispFromImage(System.Drawing.Image image)
            {
    
                return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
            }
        } 
