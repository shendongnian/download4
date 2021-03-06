    private void RadCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var items = radCheckedListBox.DataSource as IEnumerable<Peça>;
    
        if (items == null)
        {
            return;
        }
    
        var selectedItem = items.FirstOrDefault(i => i.Id == (int?)radCheckedListBox.SelectedValue);
    }
