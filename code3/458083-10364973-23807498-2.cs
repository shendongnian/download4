        System.Data.DataTable xlsData = new System.Data.DataTable();
        string xlsConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:\\romil.xlsx;Extended Properties=\"Excel 12.0;HDR=Yes;\"";
        System.Data.OleDb.OleDbConnection xlsCon = new System.Data.OleDb.OleDbConnection(xlsConnectionString);
        System.Data.OleDb.OleDbCommand xlsCommand = new System.Data.OleDb.OleDbCommand("Insert into [sheet1$] (Field1,Field2) values ('123',1)");
        xlsCommand.Connection = xlsCon;
        xlsCon.Open();
        int recUpdate = xlsCommand.ExecuteNonQuery();
        xlsCon.Close();
        Console.WriteLine(recUpdate.ToString());
        Console.ReadKey();
