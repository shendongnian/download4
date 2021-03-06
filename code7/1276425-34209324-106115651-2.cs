    using System.Diagnostics;
    ...
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Font font = new Font("Arial", 16);
        SizeF sz = g.MeasureString("Text...", font);
        Rectangle rc = new Rectangle(0,0, (int)sz.Width, (int)sz.Height);
        Debug.WriteLine(rc.Width.ToString());
        Debug.WriteLine(rc.Height.ToString());
        //change top/left origin of rectangle
        rc.X = 10;
        rc.Y = 20;
    }
