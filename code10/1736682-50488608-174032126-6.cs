    public static Bitmap BuildMonoBitmap(Byte monoBytes, Int32 width, Int32 height)
    {
        Color[] pal = new Color[] {Color.Black, Color.White};
        Int32 stride = GetMinimumStride(width);
        Bitmap monoBm = ImageUtils.BuildImage(monoBytes, width, height, stride, PixelFormat.Format1bppIndexed, pal, null);
    }
