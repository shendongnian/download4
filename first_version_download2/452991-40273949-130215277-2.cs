     protected void Button1_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString2"].ToString();
        con.Open();
        string query = "SELECT COUNT(ID) FROM Table1 WHERE pEmail= @TextBox2";
        OleDbCommand cmd = new OleDbCommand(query, con);
        
        int count = cmd.ExecuteNonQuery();
        if (count > 0)
        {
            Label1.Text = "email is already in use";
        }
        else {
            cmd.CommandText = "insert into[Table1](pName)values(@nm)";
            cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
            cmd.CommandText = "insert into[Table1](pEmail)values(@nm)";
            cmd.Parameters.AddWithValue("@nm", TextBox2.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Label1.Text = "Inserted Sucessfully!";
            }
        }
    }
