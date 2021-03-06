    private void AddGridview(DataTable dt)
    {
    	if (dt.Rows.Count > 0) {
    		GridView gridView = new GridView();
    		gridView.CssClass = "gridview";
    		gridView.DataSource = dt;
    		gridView.DataBind();
    		gridView.AutoGenerateColumns = false;
    		gridView.HeaderRow.Visible = false;
    
    		Table table = gridView.Controls(0);
    		GridViewRow gvRow = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
    		TableCell newCell = new TableCell();
    
    		newCell.ColumnSpan = dt.Columns.Count - 1;
    		newCell.Text = dt.TableName;
    
    		gvRow.Cells.Add(newCell);
    		table.Rows.AddAt(0, gvRow);
    		remittance.Controls.Add(gridView);
    	}
    }
