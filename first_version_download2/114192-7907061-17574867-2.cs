    ...
    myAdapter.UpdateCommand = new SQLiteCommand("UPDATE Dept SET DeptNo = :DeptNo, DName = :DName WHERE DeptNo = :oldDeptNo", sqConnection); 
    myAdapter.UpdateCommand.Parameters.Add("DeptNo", SQLiteType.Int32, 0, "DeptNo"); 
    myAdapter.UpdateCommand.Parameters.Add("oldDeptNo", SQLiteType.Int32, 0, "DeptNo").SourceVersion = DataRowVersion.Original;
    ...
