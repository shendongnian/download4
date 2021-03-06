    var connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    Request.QueryString.Get("ID_Persona");
    string query = "SELECT ID,Nome,Cognome,Email,CodiceFiscale FROM Persona WHERE ID = @id";
    using (SqlConnection con = new SqlConnection(connectionString))
    {
    	SqlCommand cmd = new SqlCommand(query, con);
    	cmd.Parameters.AddWithValue("@ID", "");
    	cmd.Parameters.AddWithValue("@Nome", TextBox1.Text);
    	cmd.Parameters.AddWithValue("@Cognome", TextBox15.Text);
    	cmd.Parameters.AddWithValue("@Email", TextBox20.Text);
    	cmd.Parameters.AddWithValue("@CodiceFiscale", TextBox22.Text);
    	con.Open();
    	using (var rdr = cmd.ExecuteReader())
    	{
    		while (rdr.Read())
    		{
    			IDTextBox? = rdr["Id"].ToString(),
                TextBox1.Text = rdr["Nome"].ToString(),
                TextBox15.Text = rdr["Cognome"].ToString(),
                TextBox20.Text= rdr["Email"].ToString(),
                TextBox22.Text= rdr["CodiceFiscale"].ToString(),    
    		}
    	}
    }
