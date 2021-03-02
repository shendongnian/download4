    /*Create header row above generated header row*/
     
    //create row    
    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
     
    //spanned cell that will span the columns I don't want to give the additional header 
    TableCell left = new TableHeaderCell();
    left.ColumnSpan = 6;
    row.Cells.Add(left);
     
    //spanned cell that will span the columns i want to give the additional header
    TableCell totals = new TableHeaderCell();
    totals.ColumnSpan = myGridView.Columns.Count - 3;
    totals.Text = "Additional Header";
    row.Cells.Add(totals);
     
    //Add the new row to the gridview as the master header row
    //A table is the only Control (index[0]) in a GridView
    ((Table)myGridView.Controls[0]).Rows.AddAt(0, row);
     
    /*fin*/
