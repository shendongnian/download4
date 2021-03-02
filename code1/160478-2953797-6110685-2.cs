    IDbCommand cmd = conn.CreateCommand();
    cmd.CommandText = "SomeProcedure";
    cmd.CommandType = CommandType.StoredProcedure;
    // to avoid hard coded reference to a specific provider type, get a
    // command builder object and use reflection to invoke the derive method
    DbCommandBuilder cb = dbfact.CreateCommandBuilder();
    MethodInfo mi = cb.GetType().GetMethod( "DeriveParameters", 
                                     BindingFlags.Public | BindingFlags.Static );
    mi.Invoke( null, new object[] { cmd } );
    // show information about each parameter
    foreach ( IDataParameter p in cmd.Parameters )
        Console.WriteLine( "{0}, {1}, {2}", p.ParameterName, 
                           p.DbType.ToString(), p.Direction.ToString() );
    IDataParameter prm = (IDataParameter)cmd.Parameters["SomeParam"];
    prm.Value = "xyz";
    IDataReader rdr = cmd.ExecuteReader();
