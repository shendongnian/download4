     int StatId = Convert.ToInt32(ddlState.SelectedValue);
        string CS = ConfigurationManager.ConnectionStrings["SportsActiveConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spCities", con);
            cmd.Parameters.AddWithValue("@StatId", StatId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlCity.DataSource = ds;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
        }
        ddlCity.Items.Insert(0, new ListItem("---Select---", "0"));
    
     ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByText(hf_city.Value));
