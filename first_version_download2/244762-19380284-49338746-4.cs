    public void getTables() {
        foreach(X currentTable in mapper.getTables()) {
    		var x = new X {
                TableName = currentTable.getName(),
                Fields = Fields.ToArray()
            });
    		x.GetRows = getRows(x), 
            MTables.Add(x);
        }
    }
    
    private GetRowsHandler getRows(X instance) {         
    	return () =>
    	{
    		// foreach row in something with instance
            	//yield return QvxDataRow;  
    	};
    }
