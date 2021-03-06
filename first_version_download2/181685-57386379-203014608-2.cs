public static void CompressPdf(string targetPath)
{
    using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)) {Position = 0})
    using (var source = PdfReader.Open(stream, PdfDocumentOpenMode.Import))
    using (var document = new PdfDocument())
    {
        var options = document.Options;
        options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;
        options.UseFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Automatic;
        options.CompressContentStreams = true;
        options.NoCompression = false;
        foreach (var page in source.Pages)
        {
            document.AddPage(page);
        }
        document.Save(targetPath);
    }
}
