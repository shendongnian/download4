        Document doc        = new Document(PageSize.A4);
        PdfPTable aTable                = new PdfPTable(6);
        aTable.HorizontalAlignment      = Element.ALIGN_LEFT;
        aTable.WidthPercentage          = 100;
        aTable.AddCell("Column 1");
        aTable.AddCell("Column 2");
        aTable.AddCell("Column 3");
        aTable.AddCell("Column 4");
        aTable.AddCell("Column 5");
        aTable.AddCell("Column 6");
        doc.Add(aTable);
        PdfPTable tp                    = new PdfPTable(3);
        tp.HorizontalAlignment          = Element.ALIGN_LEFT;
        tp.WidthPercentage              = 50;
        //tp.SetWidths(new []{60f, 20f, 20f});
        tp.AddCell("Col 1");
        tp.AddCell("Col 2");
        tp.AddCell("Col 3");
        doc.Add(tp);
