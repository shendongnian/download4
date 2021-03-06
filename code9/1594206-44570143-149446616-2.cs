    SpreadsheetInfo.SetLicense("License");
    ExcelFile ef = new ExcelFile();
    ExcelWorksheet ws = ef.Worksheets.Add("Error Spreadsheet info Elmah");
    
    // Write header row.
    ws.Cells[0, 0].Value = "Error ID";
    ws.Cells[0, 1].Value = "Type";
    ws.Cells[0, 2].Value = "Message";
    ws.Cells[0, 3].Value = "Time";
    ws.Cells[0, 4].Value = "Path Info";
    ws.Cells[0, 5].Value = "HTTP Host";
    
    int rowIndex = 1;
    string folder = @"C:\ErrorsMay2017";
    
    // I presume you want to write data from all XML files into a single spreadsheet.
    foreach (string file in Directory.GetFiles(folder, "*.xml"))
    {
        // Get errors records.
        var errors = from tagAttribute in XElement.Load(file).DescendantsAndSelf("error").OrderBy(x => x.Attribute("type"))
                     select new
                     {
                         ErrorID = (string)tagAttribute.Attribute("errorId"),
                         Type = (string)tagAttribute.Attribute("type"),
                         Message = (string)tagAttribute.Attribute("message"),
                         Time = (string)tagAttribute.Attribute("time"),
    
                         PathInfo = tagAttribute.Elements("serverVariables").Descendants("item").Where(x => x.Attribute("name").Value == "PATH_INFO")
                         .Select(x => x.Descendants("value").First().Attribute("string").Value).SingleOrDefault(),
    
                         HttpHost = tagAttribute.Elements("serverVariables").Descendants("item").Where(x => x.Attribute("name").Value == "HTTP_HOST")
                         .Select(x => x.Descendants("value").First().Attribute("string").Value).SingleOrDefault()
                     };
    
        // Write errors rows.
        foreach (var error in errors)
        {
            ws.Cells[rowIndex, 0].Value = error.ErrorID;
            ws.Cells[rowIndex, 1].Value = error.Type;
            ws.Cells[rowIndex, 2].Value = error.Message;
            ws.Cells[rowIndex, 3].Value = error.Time;
            ws.Cells[rowIndex, 4].Value = error.PathInfo;
            ws.Cells[rowIndex, 5].Value = error.HttpHost;
            ++rowIndex;
        }
    }
    
    // AutoFit columns after writing all spreadsheet's data.
    int columnCount = ws.CalculateMaxUsedColumns();
    for (int columnIndex = 0; columnIndex < columnCount; ++columnIndex)
        ws.Columns[columnIndex].AutoFit();
    
    // Save to newer Excel format (.xlsx).
    ef.Save(Path.Combine(folder,
        string.Format("errorlog {0}.xlsx", DateTime.Now.ToString("MM-dd-yyyy-HH-mm"))));
