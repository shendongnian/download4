    string strConn = "Data Source=SEZSW08;Initial Catalog=Nidhi;Integrated Security=True";
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string strCmd = "select companyName from companyinfo where CompanyName='" + cmbCompName.SelectedValue + "';";
            SqlCommand Cmd = new SqlCommand(strCmd, Con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, Con);
            DataSet ds = new DataSet();
            Con.Close();
            da.Fill(ds);
            cmbCompName.DataSource = ds;
            cmbCompName.DisplayMember = "CompanyName";
            cmbCompName.ValueMember = "CompanyName";
            //cmbCompName.DataBind();
            cmbCompName.Enabled = true;
