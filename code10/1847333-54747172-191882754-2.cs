    private void SaveScore()
    {
    	String scoresFilePath = @"..\..\textfiles\scores.txt";
    
    	try
    	{
    		//
    		// Create file if not exists
    		//
    		if (!File.Exists(scoresFilePath))
    		{
    			File.Create(scoresFilePath).Dispose();
    		}
    
    		//
    		// Create DataTable
    		//
    		DataColumn nameColumn = new DataColumn("name", typeof(String));
    		DataColumn scoreColumn = new DataColumn("score", typeof(int));
    
    		DataTable scores = new DataTable();
    		scores.Columns.Add(nameColumn);
    		scores.Columns.Add(scoreColumn);
    
    		//
    		// Read CSV and populate DataTable
    		//
    		using (StreamReader streamReader = new StreamReader(scoresFilePath))
    		{
    			streamReader.ReadLine();
    
    			while (!streamReader.EndOfStream)
    			{
    				String[] row = streamReader.ReadLine().Split(',');
    				scores.Rows.Add(row);
    			}
    		}
    
    		Boolean scoreFound = false;
    
    		//
    		// If user exists and new score is higher, update 
    		//
    		foreach (DataRow score in scores.Rows)
    		{
    			if ((String)score["name"] == player.Name)
    			{
    				if ((int)score["score"] < player.Score)
    				{
    					score["score"] = player.Score;
    				}
    
    				scoreFound = true;
    				break;
    			}
    		}
    
    		//
    		// If user doesn't exist then add user/score
    		//
    		if (!scoreFound)
    		{
    			scores.Rows.Add(player.Name, player.Score);
    		}
    
    		//
    		// Write changes to CSV (empty then rewrite)
    		//
    		File.WriteAllText(scoresFilePath, string.Empty);
    
    		StringBuilder stringBuilder = new StringBuilder();
    		stringBuilder.AppendLine("name,score");
    
    		foreach (DataRow score in scores.Rows)
    		{
    			stringBuilder.AppendLine(score["name"] + "," + score["score"]);
    		}
    
    		File.WriteAllText(scoresFilePath, stringBuilder.ToString());
    	}
    
    	catch(Exception ex)
    	{
    		MessageBox.Show("Error saving high score:\n\n" + ex.ToString(), "Error");
    	}
    }
