    private void DataGrid_OnAutoGeneratedColumns(object sender, EventArgs e)
    {
        DataGrid dg = sender as DataGrid;
        if (dg == null) return;
        dg.Columns.ToList().Select((col, indx) => new {Col = col, Indx = indx}).ToList().ForEach(obj => obj.Col.CanUserSort = obj.Indx == 0);
    }
