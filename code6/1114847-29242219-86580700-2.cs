    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            InitialDataLoad();
    }
    
    private void InitialDataLoad()
    {
        var dt = new DataTable();
        dt.Columns.Add("SomeData");
    
        var dr = dt.NewRow();
        dr[0] = "some data here";
        dt.Rows.Add(dr);
    
        GridView1.DataSource = dt;
        GridView1.DataBind();
    
        Session["dt"] = dt;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        // adds a row
    
        var dt = Session["dt"] as DataTable;
    
        if (dt != null)
        {
            var dr = dt.NewRow();
            dr[0] = "some more data here";
            dt.Rows.Add(dr);
    
            GridView1.DataSource = dt;
            GridView1.DataBind();
    
            Session["dt"] = dt;
        }
    }
