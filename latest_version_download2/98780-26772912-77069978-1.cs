    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            bindData();   
        }
    }
    public void bindData() {
            SqlConnection con=new SqlCponnection(ConnectionStrings);
            SqlDataAdapter da = new SqlDataAdapter("select * from  Your TableName", con);
            DataSet ds = new DataSet();
            try {
                da.Fill(ds, "YourTableName");
                GridView1.DataSource = ds;
                GridView1.DataBind();
            } catch (Exception e) {
               Response.Write( e.Message);
            } finally {
                ds.Dispose();
                da.Dispose();
                con.Dispose();
            }
