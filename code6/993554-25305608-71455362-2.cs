    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.DataPropertyName = "SomeInformation";
    col.Name = "colSomeInformation";
    col.Visible = true;
    col.HeaderText = "Some Information"
    col.DataSource = State.Instance.ProductCategories.ToList()[0];
    // set other column properties here...
    
    dataGridView.Columns.Add(col);
