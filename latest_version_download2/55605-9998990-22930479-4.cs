    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="UpdateChildGrid")
        {
        	GridViewRow row = (e.CommandSource as Button).NamingContainer as GridViewRow;
          	GridView child = row.FindControl("GridView2") as GridView;
          	// update child grid
        }
      }
