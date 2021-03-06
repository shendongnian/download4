    public async Task<IEnumerable<IDataRecord>> GetSqlDataReader1(int recordCount)
    {
        using (var sqlCon = new SqlConnection(ConnectionString))
        using (var command = new SqlCommand("sp_GetData", sqlCon))
        {
            command.Parameters.Clear();
            command.Parameters.Add("@recordCount", SqlDbType.Int).Value = recordCount;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCon.Open();               
            var rdr = await command.ExecuteReaderAsync();
            while (rdr.Read())
            {
                 yield return rdr;
            }
        }
    }
