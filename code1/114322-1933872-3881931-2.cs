    var con = new SqlConnection();
    con.ConnectionString = "connection string";
    var com = new SqlCommand();
    com.Connection = con;
    com.CommandType = CommandType.StoredProcedure;
    com.CommandText = "sp_returnTable";
    var adapt = new SqlDataAdapter();
    adapt.SelectCommand = com;
    var dataset = new DataSet();
    adapt.Fill(dataset);
