    panel1.MouseWheel += ZoomIn;
    public void ZoomIn(object sender, MouseEventArgs e)
    {
        if(e.Delta > 0)
        {
            // The user scrolled up.
        }
        else
        {
            // The user scrolled down.
        }
    }
