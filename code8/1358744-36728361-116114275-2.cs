      using(SqlConnection conn = new SqlConnection(yourConnectionString))
    {
           
            DateTime pastTime = DateTime.Now.Add(-60); 
       
         ds_DB.SelectCommand = @"SELECT * FROM [vPurchaseTotals]
         WHERE [TimeOfTransaction] >= @PastTime";
    
         SqlCommand cm = conn.CreateCommand();
         cm.CommandText = ds_DB.SelectCommand;
         
         cm.Parameters.AddWithValue("@PastTime",SqlDbType.DateTime).Value = pastTime;
    
    try
    {
      conn.Open();
     //Do what you need to do here.
    }
    catch(SqlException e)
    {
      //Handle Exception
    }
    finally
    {
      conn.Close();
    }
    
    }
