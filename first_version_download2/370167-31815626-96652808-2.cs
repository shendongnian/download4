     using (SqlCeConnection conn =
    new SqlCeConnection(@"Data Source=C:\Users\FluksikartoN\Documents\Visual Studio 2012\Projects\BuroFoki\BuroFoki\MainDB.sdf"))
    using (SqlCeCommand cmd = conn.CreateCommand())
    {
        conn.Open();
        //commands represent a query or a stored procedure       
        cmd.CommandText = "SELECT buyEURrate FROM CurrencyRates";
        using (SqlCeDataReader rd = cmd.ExecuteReader())
        {
             if(rd.Read())
            {
               double variable = rd.GetDouble(0);
            }
        }
        conn.Close();
    }
