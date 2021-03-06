	private async Task LoginToDBAsync() // notice the async keyword in the method signature
	{
		string ServerPath = Server.Text;
		string Database = Schema.Text;
		dbStr = "Server=" + ServerPath + ";Database=" + Database + ";Trusted_Connection=True;";
		try
		{
			using (SqlConnection conn = new SqlConnection(dbStr))
			{
				await conn.OpenAsync(); // will release the thread back to the WPF app and connection continues on new thread until it completes
				conn.Close();
			}
		}
		catch (Exception ex)
		{
			if (ex.Message != null)
			{
				MessageBoxButton btn = MessageBoxButton.OK;
				ModernDialog.ShowMessage(ex.Message, "Failure to connect", btn);
			}
		}
	}
	async void bw_DoWorkConnect(object sender, DoWorkEventArgs e) // notice the async keyword in the method signature. Because its a WPF event callback it returns void and not Task like the above method
	{
		await LoginToDBAsync();
	}
