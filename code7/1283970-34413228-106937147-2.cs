     using (SqlConnection connection = new SqlConnection("Server..."))
     {
         string command = "insert into Records values (...)";
         var command = new SqlCommand(command, connection);
         command.ExecuteNonQuery();
     }
