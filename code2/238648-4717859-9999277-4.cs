    SqlConnection connection = null;
    try
    {
        connection = new SqlConnection(connectionString);
    }
    finally
    {
       if(connection != null)
            ((IDisposable)connection).Dispose();
    }
