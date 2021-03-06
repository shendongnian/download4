    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserTypesList(ddlUserTypes);
        }
    }
    
       private void UserTypesList(DropDownList ddList)
    {
        StaticDataProvider stDataProv = new StaticDataProvider();
        ddList.DataSource = stDataProv.UserTypes();
        ddList.DataTextField = "Value";
        ddList.DataValueField = "Key";
        ddList.DataBind();
    }
