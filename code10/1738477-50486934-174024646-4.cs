    PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
    Document doc = new Document(pdfDoc, PageSize.A4, true);
    ImprovedVariableHeaderEventHandler handler = new ImprovedVariableHeaderEventHandler();
    pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);
    List<int> factors;
    for (int i = 2; i < 40; i++)
    {
        if (2 != i)
        {
            doc.Add(new AreaBreak());
        }
        factors = getFactors(i);
        if (factors.Count == 1)
        {
            doc.Add(new Paragraph("This is a prime number!"));
        }
        foreach (int factor in factors)
        {
            doc.Add(new Paragraph("Factor: " + factor));
        }
        handler.setHeaderFor(String.Format("THE FACTORS OF {0}", i), pdfDoc.GetLastPage());
    }
    doc.Close();
