    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    if (xlApp != null)
    {
        xlApp.Visible = true;
        Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Worksheet wsPatient = (Worksheet)wb.Worksheets[1];
        wsPatient.Name = "ThePatientName";
    }
