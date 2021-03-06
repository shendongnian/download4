    try
    {
        transaction.Rollback();
    }
    catch (Exception ex2)
    {
        // This catch block will handle any errors that may have occurred 
        // on the server that would cause the rollback to fail, such as 
        // a closed connection.
        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
        Console.WriteLine("  Message: {0}", ex2.Message);
    }
