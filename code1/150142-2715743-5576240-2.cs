    public void ExecuteNonQuery(SqlCommand Cmd) 
    { 
        //========== Connection ==========// 
        using(SqlConnection Conn = new SqlConnection(strConStr))
        { 
            //========== Open Connection ==========// 
            Conn.Open(); 
 
            //========== Execute Command ==========// 
            Cmd.Connection = Conn; 
            Cmd.CommandTimeout = 180; 
            Cmd.ExecuteNonQuery(); 
        } 
    } 
