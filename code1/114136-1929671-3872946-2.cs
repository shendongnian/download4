    ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[name];
    DbProviderFactory factory = DbProviderFactories.GetFactory(c.ProviderName)
    ...
    IDbConnection connection = _factory.CreateConnection();
    connection.ConnectionString = c.ConnectionString;
    ...
