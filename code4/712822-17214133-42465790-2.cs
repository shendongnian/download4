    using (TransactionScope scope = new TransactionScope(TransactionScope.Required, 
     new TransactionOptions 
         { IsolationLevel = IsolationLEvel.ReadCommitted}))
    {
       try 
       {
           // Delete file from database
           // Delete physical file 
           // commit
       }
       catch (Exception ex)
       {
           // no commit, so database deletion will be rolled back
       }       
    }
