    try{
        using (var con = new System.Data.SqlClient.SqlConnection(conString)) { 
            using(var cmd = new System.Data.SqlClient.SqlCommand(command)){
                var reader = cmd.ExecuteReader();
                while (reader.Read()) { 
                    //do something
                }
            }//will automatically close connection
        }
    }
    catch (Exception ex) { 
        //log exception or throw
        throw;
    }
