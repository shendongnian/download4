    private void UpdateLocation(string newLocation, string query, string connectionString)
    {
      //Using using statements calls close as well as dispose
      using(SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        using (SqlCommand comm = conn.CreateCommand())
        {
          comm.CommandText = "Update ReaderUHF Set Location = @location where EPC = @query";
          //Always use Parameters to avoid SQL injection
          comm.Parameters.AddWithValue("@location", newLocation);
          comm.Parameters.AddWithValue("@query", query);
          comm.ExecuteNonQuery();
        }
      }
    }
    private void UpdateIdentification(string identification, string query, string connectionString)
    {
      using(SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        using (SqlCommand comm = conn.CreateCommand())
        {
          comm.CommandText = "Update ReaderUHF Set Identification = @identification where EPC = @query";
          comm.Parameters.AddWithValue("@identification", identification);
          comm.Parameters.AddWithValue("@query", query);
          comm.ExecuteNonQuery();
        }
      }
    }
