    using (OleDbconnection connection = new OleDbconnection (ConnectionString))
    {
       connection.Open();
       OleDbCommand select = new OleDbCommand("..selecte query",connection);
       OleDbDataReader reader = select.ExecuteReader();
    
       if (reader.HasRows)
       {
          while (reader.Read())
          {
             //read data you want 
            //you might not need another connection , but i added to seperate it , you can reuse connection you created and perfrom update 
            using(OleDbconnection connection1 = new OleDbconnection (ConnectionString))
               {
                   OleDbCommand insert= new OleDbCommand ("..insertquery", connection1);
                insert.ExecuteNonQuery();
               }
             }
          }
    
          reader.Close();
       }
    }
