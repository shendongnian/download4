     int k=0;
     bool addRow;
     for (int i = 0; i < dgv.Rows.Count; i++)
     {
    	 addRow=true;
         for (int j = 0; j < dgv.ColumnCount; j++)
         {
            if (dgv.Rows[i].Cells[j].Selected == true)
            {
    			if(addRow){
    				dt.Rows.Add();
    				addRow=false;
    				k++;
    			}
    			dt.Rows[k-1][j] = dgv.Rows[i].Cells[j].Value;
            }
         }
      }
       dt.AcceptChanges();
