    unsafe bool ArePixelsEqual(byte* p1, byte* p2, int bytesPerPixel)
    {
        for (int i = 0; i < bytesPerPixel; ++i)
            if (p1[i] != p2[i])
                return false;
        return true;
    }
    private static unsafe List<Rectangle> CodeImage(Bitmap bmp, Bitmap bmp2)
    {
        if (bmp.PixelFormat != bmp2.PixelFormat || bmp.Width != bmp2.Width || bmp.Height != bmp2.Height)
            throw new ArgumentException();
        List<Rectangle> rec = new List<Rectangle>();
        var bmData1 = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        var bmData2 = bmp2.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp2.PixelFormat);
        int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;        
        IntPtr scan01 = bmData1.Scan0;
        IntPtr scan02 = bmData2.Scan0;
        int stride1 = bmData1.Stride;
        int stride2 = bmData2.Stride;
        int nWidth = bmp.Width;
        int nHeight = bmp.Height;
        bool[] visited = new bool[nWidth * nHeight];
        byte* base1 = (byte*)scan01.ToPointer();
        byte* base2 = (byte*)scan02.ToPointer();
            for (int y = 0; y < nHeight; y++)
            {
                byte* p1 = base1;
                byte* p2 = base2;
                for (int x = 0; x < nWidth; ++x)
                {
                    if (!ArePixelsEqual(p1, p2, bytesPerPixel) && !(visited[x + nWidth * y]))
                    {
                        // fill the different area
                        int minX = x;
                        int maxX = x;
                        int minY = y;
                        int maxY = y;
                        var pt = new Point(x, y);
                        Stack<Point> toBeProcessed = new Stack<Point>();
                        visited[x + nWidth * y] = true;
                        toBeProcessed.Push(pt);
                        while (toBeProcessed.Count > 0)
                        {
                            var process = toBeProcessed.Pop();
                            var ptr1 = (byte*)scan01.ToPointer() + process.Y * stride1 + process.X * bytesPerPixel;
                            var ptr2 = (byte*)scan02.ToPointer() + process.Y * stride2 + process.X * bytesPerPixel;
                            //Check pixel equality
                            if (ArePixelsEqual(ptr1, ptr2, bytesPerPixel))
                                continue;
                            //This pixel is different
                            //Update the rectangle
                            if (process.X < minX) minX = process.X;
                            if (process.X > maxX) maxX = process.X;
                            if (process.Y < minY) minY = process.Y;
                            if (process.Y > maxY) maxY = process.Y;
                            Point n; int idx;
                            //Put neighbors in stack
                            if (process.X - 1 >= 0)
                            {
                                n = new Point(process.X - 1, process.Y); idx = n.X + nWidth * n.Y;
                                if (!visited[idx]) { visited[idx] = true; toBeProcessed.Push(n); }
                            }
                            if (process.X + 1 < nWidth)
                            {
                                n = new Point(process.X + 1, process.Y); idx = n.X + nWidth * n.Y;
                                if (!visited[idx]) { visited[idx] = true; toBeProcessed.Push(n); }
                            }
                            if (process.Y - 1 >= 0)
                            {
                                n = new Point(process.X, process.Y - 1); idx = n.X + nWidth * n.Y;
                                if (!visited[idx]) { visited[idx] = true; toBeProcessed.Push(n); }
                            }
                            if (process.Y + 1 < nHeight)
                            {
                                n = new Point(process.X, process.Y + 1); idx = n.X + nWidth * n.Y;
                                if (!visited[idx]) { visited[idx] = true; toBeProcessed.Push(n); }
                            }
                        }
                        rec.Add(new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1));
                    }
                    p1 += bytesPerPixel;
                    p2 += bytesPerPixel;
                }
                base1 += stride1;
                base2 += stride2;
            }
        
        bmp.UnlockBits(bmData1);
        bmp2.UnlockBits(bmData2);
        return rec;
    }
