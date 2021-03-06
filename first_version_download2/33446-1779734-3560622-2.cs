    public void ReadTable(string tableName, Action<string> _setNameAction) {
        DataTable table = GetDataTable(tableName);
        foreach (DataRow row in table.Rows) {
            int id = Convert.ToInt32(row["id"]);
            string name = row["name"].ToString();
            _setNameAction(name);
        }
    }
