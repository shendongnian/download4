    private void gridView1_ShowFilterPopupCheckedListBox(object sender, FilterPopupCheckedListBoxEventArgs e)
    {
        if (!(e.Column.ColumnEdit is RepositoryItemCheckedComboBoxEdit)) { return; }
        var distinctAtomicValues =
            (from value in
                 (from atomicItemValues in
                      from item in e.CheckedComboBox.Items.OfType<CheckedListBoxItem>()
                      let itemValue = (string)(item.Value as FilterItem).Value
                      where itemValue != null
                      select itemValue.Split(';')
                  from atomicValue in atomicItemValues
                  let trimmedAtomicValue = atomicValue.Trim()
                  orderby trimmedAtomicValue
                  select trimmedAtomicValue).Distinct()
             select new CheckedListBoxItem(value)).ToList();
        e.CheckedComboBox.Items.Clear();
        foreach (var atomicItem in distinctAtomicValues)
            e.CheckedComboBox.Items.Add(atomicItem);
    }
