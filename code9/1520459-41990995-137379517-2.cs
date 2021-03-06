    protected void Page_Load(object sender, EventArgs e)
    {
        //always create the controls on every page load if there is a value selected in ddlScalaTaglie
        if (!string.IsNullOrEmpty(ddlScalaTaglie.SelectedValue))
        {
            createTable(ddlScalaTaglie.SelectedValue);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //use findcontrol to find the Table inside the placeholder
        Table tbl = Page.FindControl("divTaglieRighe").FindControl("Table1") as Table;
        foreach (TableRow row in tbl.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                foreach (Control ctrl in cell.Controls)
                {
                    //the control is a textbox
                    if (ctrl is TextBox)
                    {
                        //cast the control back to a textbox
                        TextBox tb = ctrl as TextBox;
                        //does the checkbox have a value, if so append the label
                        if (!string.IsNullOrEmpty(tb.Text))
                        {
                            Label1.Text += tb.Text + "<br>";
                        }
                    }
                }
            }
        }
    }
    protected void ddlScalaTaglie_SelectedIndexChanged(object sender, EventArgs e)
    {
        //check if ddlScalaTaglie has a value, if not reset the placeholder
        if (string.IsNullOrEmpty(ddlScalaTaglie.SelectedValue))
        {
            divTaglieRighe.Controls.Clear();
            //no need to create the Table dynamically, that will be handled in Page_Load
        }
    }
    private void createTable(string value)
    {
        DataTable dtRighe = Common.LoadFromDB();
        //create a new table WITH id, that is needed for findcontrol
        Table tbl = new Table();
        tbl.ID = "Table1";
        //loop all rows in the datatable
        foreach (DataRow dr in dtRighe.Rows)
        {
            TableRow tr = new TableRow();
            //ean
            TableCell tcEAN = new TableCell();
            TextBox tbEAN = new TextBox();
            tbEAN.ID = "txtEAN" + dr[0].ToString();
            tbEAN.Width = new Unit(100, UnitType.Percentage);
            tbEAN.Columns = 15;
            tcEAN.Controls.Add(tbEAN);
            tr.Controls.Add(tcEAN);
            //Qty
            TableCell tcQty = new TableCell();
            TextBox tbQty = new TextBox();
            tbQty.ID = "txtQty" + dr[0].ToString();
            tbQty.TextMode = TextBoxMode.Number;
            tcQty.Controls.Add(tbQty);
            tr.Controls.Add(tcQty);
            tbl.Controls.Add(tr);
        }
        //add the table to the placeholder
        divTaglieRighe.Controls.Add(tbl);
    }
