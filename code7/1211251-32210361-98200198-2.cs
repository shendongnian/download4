    using System.Data;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    public void ExportDataTable(
         DataTable table,
         string exportFile)
        {
            //create the empty spreadsheet template and save the file
            //using the class generated by the Productivity tool
            ExcelDocument excelDocument = new ExcelDocument();
            excelDocument.CreatePackage(exportFile);
            //populate the data into the spreadsheet
            using (SpreadsheetDocument spreadsheet =
                SpreadsheetDocument.Open(exportFile, true))
            {
                WorkbookPart workbook = spreadsheet.WorkbookPart;
                //create a reference to Sheet1
                WorksheetPart worksheet = workbook.WorksheetParts.Last();
                SheetData data = worksheet.Worksheet.GetFirstChild<SheetData>();
                //add column names to the first row
                Row header = new Row();
                header.RowIndex = (UInt32)1;
                foreach (DataColumn column in table.Columns)
                {
                    Cell headerCell = createTextCell(
                        table.Columns.IndexOf(column) + 1,
                        1,
                        column.ColumnName);
                    header.AppendChild(headerCell);
                }
                data.AppendChild(header);
                //loop through each data row
                DataRow contentRow;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    contentRow = table.Rows[i];
                    data.AppendChild(createContentRow(contentRow, i + 2));
                }
            }
        }
