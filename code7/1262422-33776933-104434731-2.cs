	var serverConnection = new ServerConnection(new SqlConnection(ConnectionString));
	var server = new Server(serverConnection);
	foreach (StoredProcedure sp in server.Databases["YourDB"].StoredProcedures)
	{
		if (sp.Name.Contains("yourSubstring"))
		{
			System.IO.File.WriteAllText(sp.TextHeader + Environment.NewLine + sp.TextBody);
		}
	}
