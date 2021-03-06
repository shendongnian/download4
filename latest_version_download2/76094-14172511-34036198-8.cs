        private void dataGrid1_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var dg = sender as DataGrid;
            var first = dg.ItemsSource.Cast<object>().FirstOrDefault() as DynamicObject;
            if (first == null) return;
            var names = first.GetDynamicMemberNames();
            foreach(var name in names)
            {
                dg.Columns.Add(new DataGridTextColumn { Header = name, Binding = new Binding(name) });            
            }            
        }
