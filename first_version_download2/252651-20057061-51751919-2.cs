    if (ddl.SelectedItem.Equals("it"))
    {
        ddlProv.Enabled = true;
        Page.Validate("pivaItalia");
    }
    else
    {
        ddlProv.SelectedIndex = 0;
        ddlProv.Enabled = false;
    }
