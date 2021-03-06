csharp
public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
{
    int diameter = radius * 2;
    Size size = new Size(diameter, diameter);
    Rectangle arc = new Rectangle(bounds.Location, size);
    GraphicsPath path = new GraphicsPath();
    if (radius == 0)
    {
        path.AddRectangle(bounds);
        return path;
    }
    // top left arc  
    path.AddArc(arc, 180, 90);
    // top right arc  
    arc.X = bounds.Right - diameter;
    path.AddArc(arc, 270, 90);
    // bottom right arc  
    arc.Y = bounds.Bottom - diameter;
    path.AddArc(arc, 0, 90);
    // bottom left arc 
    arc.X = bounds.Left;
    path.AddArc(arc, 90, 90);
    path.CloseFigure();
    return path;
}
public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
{
    if (graphics == null)
        throw new ArgumentNullException("graphics");
    if (brush == null)
        throw new ArgumentNullException("brush");
    using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
    {
        graphics.FillPath(brush, path);
    }
}
And let's add it to the drawing call.
csharp
private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics graphics = e.Graphics;
    Rectangle gradientRectangle = new Rectangle(-1, -1, this.Width + 1, this.Height + 1);
    Brush b = new LinearGradientBrush(gradientRectangle, Color.DarkSlateBlue, Color.MediumPurple, 0.0f);
    graphics.SmoothingMode = SmoothingMode.HighQuality;
    FillRoundedRectangle(graphics, b, gradientRectangle, 35);
}
[![Rounded Rectangle Form][1]][1]
Then we can draw the same form as the picture above.
Second, draw a form using Per Pixel Alpha Blend.
csharp
public void SetBitmap(Bitmap bitmap)
{
    SetBitmap(bitmap, 255);
}
public void SetBitmap(Bitmap bitmap, byte opacity)
{
    if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
        throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
    IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
    IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
    IntPtr hBitmap = IntPtr.Zero;
    IntPtr oldBitmap = IntPtr.Zero;
    try
    {
        hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
        oldBitmap = Win32.SelectObject(memDc, hBitmap);
        Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
        Win32.Point pointSource = new Win32.Point(0, 0);
        Win32.Point topPos = new Win32.Point(Left, Top);
        Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
        blend.BlendOp = Win32.AC_SRC_OVER;
        blend.BlendFlags = 0;
        blend.SourceConstantAlpha = opacity;
        blend.AlphaFormat = Win32.AC_SRC_ALPHA;
        Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
    }
    finally
    {
        Win32.ReleaseDC(IntPtr.Zero, screenDc);
        if (hBitmap != IntPtr.Zero)
        {
            Win32.SelectObject(memDc, oldBitmap);
            Win32.DeleteObject(hBitmap);
        }
        Win32.DeleteDC(memDc);
    }
}
protected override CreateParams CreateParams
{
    get
    {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x00080000;
        return cp;
    }
}
Finally, call SetBitmap when loading a form.
csharp
private void Form1_Load(object sender, EventArgs e)
{
    Bitmap myBitmap = new Bitmap(this.Width, this.Height);
    Graphics graphics = Graphics.FromImage(myBitmap);
    Rectangle gradientRectangle = new Rectangle(-1, -1, this.Width + 1, this.Height + 1);
    Brush b = new LinearGradientBrush(gradientRectangle, Color.DarkSlateBlue, Color.MediumPurple, 0.0f);
    graphics.SmoothingMode = SmoothingMode.HighQuality;
    FillRoundedRectangle(graphics, b, gradientRectangle, 35);
    SetBitmap(myBitmap);
}
When you finish the above tasks, you can finally get Smooth Round Corners in WinForm Applications.
[![Smooth Round Corners Form][2]][2]
code of form
csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.None;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        Bitmap myBitmap = new Bitmap(this.Width, this.Height);
        Graphics graphics = Graphics.FromImage(myBitmap);
        Rectangle gradientRectangle = new Rectangle(-1, -1, this.Width + 1, this.Height + 1);
        Brush b = new LinearGradientBrush(gradientRectangle, Color.DarkSlateBlue, Color.MediumPurple, 0.0f);
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        FillRoundedRectangle(graphics, b, gradientRectangle, 35);
        SetBitmap(myBitmap);
    }
    public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();
        if (radius == 0)
        {
            path.AddRectangle(bounds);
            return path;
        }
        // top left arc  
        path.AddArc(arc, 180, 90);
        // top right arc  
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        // bottom right arc  
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        // bottom left arc 
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        return path;
    }
    public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
    {
        if (graphics == null)
            throw new ArgumentNullException("graphics");
        if (pen == null)
            throw new ArgumentNullException("pen");
        using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
        {
            graphics.DrawPath(pen, path);
        }
    }
    public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
    {
        if (graphics == null)
            throw new ArgumentNullException("graphics");
        if (brush == null)
            throw new ArgumentNullException("brush");
        using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
        {
            graphics.FillPath(brush, path);
        }
    }
    public void SetBitmap(Bitmap bitmap)
    {
        SetBitmap(bitmap, 255);
    }
    public void SetBitmap(Bitmap bitmap, byte opacity)
    {
        if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
        IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
        IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
        IntPtr hBitmap = IntPtr.Zero;
        IntPtr oldBitmap = IntPtr.Zero;
        try
        {
            hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
            oldBitmap = Win32.SelectObject(memDc, hBitmap);
            Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
            Win32.Point pointSource = new Win32.Point(0, 0);
            Win32.Point topPos = new Win32.Point(Left, Top);
            Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
            blend.BlendOp = Win32.AC_SRC_OVER;
            blend.BlendFlags = 0;
            blend.SourceConstantAlpha = opacity;
            blend.AlphaFormat = Win32.AC_SRC_ALPHA;
            Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
        }
        finally
        {
            Win32.ReleaseDC(IntPtr.Zero, screenDc);
            if (hBitmap != IntPtr.Zero)
            {
                Win32.SelectObject(memDc, oldBitmap);
                Win32.DeleteObject(hBitmap);
            }
            Win32.DeleteDC(memDc);
        }
    }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x00080000;
            return cp;
        }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (DesignMode)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradientRectangle = new Rectangle(-1, -1, this.Width + 1, this.Height + 1);
            Brush b = new LinearGradientBrush(gradientRectangle, Color.DarkSlateBlue, Color.MediumPurple, 0.0f);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            FillRoundedRectangle(graphics, b, gradientRectangle, 35);
        }
    }
}
  [1]: https://i.stack.imgur.com/ZAJ6h.png
  [2]: https://i.stack.imgur.com/3HY2g.png
