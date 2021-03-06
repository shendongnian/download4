    public string ExportToCSVFile(DataTable dtTable)
    {
    	StringBuilder sbldr = new StringBuilder();
    	if (dtTable.Columns.Count != 0)
    	{
    		foreach (DataColumn col in dtTable.Columns)
    		{
    			sbldr.Append(col.ColumnName.Replace(",", "") + ',');
    		}
    		sbldr.Append("\r\n");
    		foreach (DataRow row in dtTable.Rows)
    		{
    			foreach (DataColumn column in dtTable.Columns)
    			{
    				sbldr.Append(row[column].ToString().Replace(",", "").Trim() + ',');
    			}
    			sbldr.Append("\r\n");
    		}
    	}
    	return sbldr.ToString();
    }
