    long offset = 0x10000000;  
    long length = 0x20000000; // 512 megabytes 
    
    // Create the memory-mapped file. 
    using (var mmf = MemoryMappedFile.CreateFromFile(@"c:\ExtremelyLargeImage.data", FileMode.Open,"ImgA"))
    {
        // Create a random access view, from the 256th megabyte (the offset) 
        // to the 768th megabyte (the offset plus length). 
        using (var accessor = mmf.CreateViewAccessor(offset, length))
        {
            int colorSize = Marshal.SizeOf(typeof(MyColor));
            MyColor color;
    
            // Make changes to the view. 
            for (long i = 0; i < length; i += colorSize)
            {
                accessor.Read(i, out color);
                color.Brighten(10);
                accessor.Write(i, ref color);
            }
        }
    }
