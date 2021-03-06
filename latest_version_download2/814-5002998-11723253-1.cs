    public string ReadPdfFile(object Filename, DataTable ReadLibray)
    {
    	PdfReader reader2 = new PdfReader((string)Filename);
    	string strText = string.Empty;
    
    	for (int page = 1; page <= reader2.NumberOfPages; page++)
    	{
    	ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
    	PdfReader reader = new PdfReader((string)Filename);
    	String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
    
    	s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
    	strText = strText + s;
    	reader.Close();
    	}
    	return strText;
    }
