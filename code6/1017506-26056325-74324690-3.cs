    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
      {
         if (e.CommandName == "bind")
         {
           Loaddata1(); 
         }
 
      }
