    using (System.Data.SqlClient.SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString)) { 
        con.Open(); 
        SqlCommand cmd = new SqlCommand(); 
        string expression = "Parameter value"; 
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.CommandText = "Your Stored Procedure"; 
        cmd.Parameters.Add("Your Parameter Name", 
                    SqlDbType.VarChar).Value = expression;    
        cmd.Connection = con; 
        using (IDataReader dr = cmd.ExecuteReader()) 
        { 
            if (dr.Read()) 
            { 
            } 
        } 
    }
