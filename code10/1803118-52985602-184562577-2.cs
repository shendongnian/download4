    int[] selectedRows = gridView4.GetSelectedRows();
    for (int i = 0; i < selectedRows.Length; i++)
    {
         // Get a DataRow and fill it with all values from the this selected row
         // This is where you went wrong, you kept using only the first selected row
         DataRow rowGridView4 = (gridView4.GetRow(selectedRows[i]) as DataRowView).Row;
         // fix for error  "This row already belongs to another table"
         DataRox row = EmplDT.NewRow();
         row[0] = rowGridView4[0];
         row[1] = rowGridView4[1];
         // Do a check for doubles here
         DataRow[] doubles = EmplDT.Select("Matricule = " + row[0].ToString());
         if (doubles.Length > 0)
         {
             XtraMessageBox.Show(Resources.employeeAlreadyAdded, Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
             return;         
         }
         // Edit any values in row if needed
         row[2] = userShift.Text;
         row[3] = userShift.EditValue;
         row[4] = txtDate.EditValue;
         EmplDT.Rows.Add(row);
    }
