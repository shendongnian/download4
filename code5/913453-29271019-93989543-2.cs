	DataObject o = (DataObject)Clipboard.GetDataObject();
	if (o.GetDataPresent(DataFormats.Text))
	{
		if (myDataGridView.RowCount > 0)
			myDataGridView.Rows.Clear();
	
		if (myDataGridView.ColumnCount > 0)
			myDataGridView.Columns.Clear();
	
		bool columnsAdded = false;
		string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
		int j=0;
		foreach (string pastedRow in pastedRows)
		{
			string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
	
			if (!columnsAdded)
			{
				for (int i = 0; i < pastedRowCells.Length; i++)
					myDataGridView.Columns.Add("col" + i, pastedRowCells[i]);
	
				columnsAdded = true;
				continue;
			}
	
			myDataGridView.Rows.Add();
			int myRowIndex = myDataGridView.Rows.Count - 1;
	
			using (DataGridViewRow myDataGridViewRow = myDataGridView.Rows[j])
			{
				for (int i = 0; i < pastedRowCells.Length; i++)
					myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
			}
			j++;
		}
	}
