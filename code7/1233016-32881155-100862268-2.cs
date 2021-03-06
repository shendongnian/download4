    private DataTable Table_c;
    private DataTable Table_a;
    private DataSet tblDataSet;
    private void Form1_Load(object sender, EventArgs e)
    {
        Table_a = this.table_aTableAdapter1.GetData();
        Table_c = this.table_cTableAdapter.GetData();
    
        tblDataSet = new DataSet();
        tblDataSet.Tables.Add(Table_a);
        tblDataSet.Tables.Add(Table_c);    
        tblDataSet.Relations.Add("Relation1", Table_c.Columns["Number"], Table_a.Columns["Number"]);
    
        BindingSource bsC = new BindingSource();
        bsC.DataSource = tblDataSet;
        bsC.DataMember = "Table_c";
    
        BindingSource bsA = new BindingSource();
        bsA.DataSource = bsC;
        bsA.DataMember = "Relation1";
    
        table_cDataGridView.DataSource = bsC;
        table_aDataGridView.DataSource = bsA; 
    }
