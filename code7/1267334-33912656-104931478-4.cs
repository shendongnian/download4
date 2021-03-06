    bool firstRowContainsheader = true;
    var tableRows =  doc.DocumentNode.Descendants("tr");
    var tableData = tableRows.Skip(firstRowContainsheader ? 1 : 0)
        .Select(row => row.Descendants("td")
            .Select((cell, index) => new { row, cell, index, cell.InnerText })
            .ToList());
    DataTable table = new DataTable();
    int columnIndex = 0;
    var headerCells = tableRows.First().Descendants()
        .Where(n => n.Name == "td" || n.Name == "th");
    foreach (HtmlNode cell in headerCells)
    { 
        string colName = firstRowContainsheader 
            ? cell.InnerText 
            : String.Format("Column {0}", (++columnIndex).ToString());
        table.Columns.Add(colName, typeof(string));
    }
    foreach (var rowCells in tableData)
    {
        DataRow row = table.Rows.Add();
        for (int i = 0; i < rowCells.Count; i++)
        {
            row.SetField(i, rowCells[i].InnerText);
        }
    }
