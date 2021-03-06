      protected DataTable ExecuteSqlDataReader(string connection, string sqlQuery, SqlParameter[] cmdParams)
      {
         SqlConnection con = new SqlConnection(connection);
         SqlCommand cmd = new SqlCommand(sqlQuery, con);
         cmd.Parameters = cmdParams;
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         sda.Fill(dt);
         sda.Command.Close();
         return dt;
      }
