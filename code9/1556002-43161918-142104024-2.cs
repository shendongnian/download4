	public int GetLatestAccountID(string connectionString) 
	{
		var dbConn = new OleDbConnection(connectionString);
		using(dbConn)
		{
			dbConn.Open();
	
			string query = "select Max(AccountID) as maxID from Account";
			using(var dbCommand = new OleDbCommand(query, dbConn))
			{
				var value = dbCommand.ExecuteScalar();
				if (value != DBNull.Value)
					return Convert.ToInt32(value) + 1;
	
				return 1;
			}
		}
	}
