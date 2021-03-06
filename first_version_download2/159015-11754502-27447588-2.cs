    (1) create a new DataTable 
        DataTable dt = new DataTable ("Table_AX"); 
        
    (2) Add columns to the DataTable 
        // Method 1 
        dt.Columns.Add ("column0", System.Type.GetType ("System.String")); 
        // Method 2 
        DataColumn dc = new DataColumn ("column1", System.Type.GetType ("System.Boolean")); 
        dt.Columns.Add (dc); 
        
    (3) to add rows to the DataTable 
        // Initialize the row 
        DataRow dr = dt.NewRow (); 
        dr ["column0"] = "AX"; 
        dr ["column1"] = true; 
        dt.Rows.Add (dr); 
        // Doesn't initialize the row 
        DataRow dr1 = dt.NewRow (); 
        dt.Rows.Add (dr1); 
    
