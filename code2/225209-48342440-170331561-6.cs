    public static void Distinct(this DataTable dataTable, string distinctColumnName)
    {
    	var distinctResult = new DataTable();
        distinctResult.Merge(
    					 .GroupBy(row => row.Field<object>(distinctColumnName))
    					 .Select(group => group.First())
    					 .CopyToDataTable()
    			);
    	if (distinctResult.DefaultView.Count < dataTable.DefaultView.Count)
    	{
    		dataTable.Clear();
    		dataTable.Merge(distinctResult);
    		dataTable.AcceptChanges();
    	}
    }
