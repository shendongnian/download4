    protected void Page_Load(object sender, EventArgs e)
        {
            this.form1.DefaultButton = "Button1";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("View1 Button is clicked");
            MultiView1.ActiveViewIndex = 1;
            this.form1.DefaultButton = "Button2";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("View2 Button is clicked");
            MultiView1.ActiveViewIndex = 0;
        }
