    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
      if (e.CommandName == "content")
      {
        Response.Redirect("content.aspx?content=" +e.CommandArgument.ToString());
      }
    }
