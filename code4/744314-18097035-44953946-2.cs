    PdfPTable table = new PdfPTable(2);
    table.DefaultCell.Border = PdfPCell.NO_BORDER;
    table.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
    table.addCell(new Phrase("789456|", f5));
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
    table.addCell(new Phrase("Test", f5));
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
    table.addCell(new Phrase("456|", f5));
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
    table.addCell(new Phrase("Test", f5));
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
    table.addCell(new Phrase("12345|", f5));
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
    table.addCell(new Phrase("Test", f5));
    doc.Add(table);
