    public async void Button1_Click(object sender, EventArgs args)
    {
        await Task.Run(()=>m_camera.GrabImage();
        //Back in the UI thread
        SaveImage();
        var copyBmp = (Bitmap)mImage.bmp.Clone();
        pictureBox1.Image = copyBmp;
        m_camera.ReleaseImage();
    }
