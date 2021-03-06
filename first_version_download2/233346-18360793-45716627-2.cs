            DataGridTemplateColumn cboColumn = new DataGridTemplateColumn();
            cboColumn.Header = colName;
            //DataTemplate for CellTemplate
            DataTemplate cellTemplate = new DataTemplate();
            FrameworkElementFactory txtBlkFactory = new FrameworkElementFactory(typeof(TextBlock));
            txtBlkFactory.SetValue(TextBlock.TextProperty, textBinding);
            cellTemplate.VisualTree = txtBlkFactory;
            cboColumn.CellTemplate = cellTemplate;
            //DataTemplate for CellEditingTemplate
            DataTemplate editTemplate = new DataTemplate();
            FrameworkElementFactory cboFactory = new FrameworkElementFactory(typeof(ComboBox));
            cboFactory.SetValue(ComboBox.TextProperty, textBinding);
            cboFactory.SetValue(ComboBox.ItemsSourceProperty, statusItemsList);
            cboFactory.SetValue(ComboBox.IsEditableProperty, true);
            editTemplate.VisualTree = cboFactory;
            cboColumn.CellEditingTemplate = editTemplate;
