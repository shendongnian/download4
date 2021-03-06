    public static readonly byte[] PngSignature = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
    /// <summary>
    /// Convert a PNG from file path to byte array.
    /// </summary>
    /// <param name="imagePath">A relative or absolute path for the png file that need to be convert to byte array.</param>
    /// <returns>A byte array representation on the png file.</returns>
    public static byte[] PngImageToBinary(string imagePath)
    {
        if (!File.Exists(imagePath)) // Check file exist
            throw new FileNotFoundException("File not found", imagePath);
        if (Path.GetExtension(imagePath)?.ToLower() != ".png") // Check file extension
            throw new ArgumentOutOfRangeException(imagePath, "Requiere a png extension");
        // Read stream
        byte[] b;
        using (var fS = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
        }
        // Check first bytes of file, a png start with "PngSignature" bytes
        if (b == null
            || b.Length < PngSignature.Length
            || PngSignature.Where((t, i) => b[i] != t).Any())
            throw new IOException($"{imagePath} is corrupted");
    
        return b;
    }
