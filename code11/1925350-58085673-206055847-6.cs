    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Params.Get("__EVENTARGUMENT") == "true")
        {
            // call a method.
            TextChanger();
        }
    }
    protected void TextChanger()
    {
        if (DropDownList1.SelectedItem.Text == "02")
        {
            Label2.Text = "changed text";
        }
    }
