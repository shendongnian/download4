    void PrintBitmap(Bitmap bm)
    {
        PrintDocument doc = new PrintDocument();
        doc.PrintPage += (s, ev) => {
            ev.Graphics.DrawImage(bm, Point.Empty); // adjust this to put the image elsewhere
            ev.HasMorePages = false;
        };
        doc.Print();
    }
