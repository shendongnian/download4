    private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
    {
      DependencyObject cellItemContainer = this.datagrid.ItemContainerGenerator.ContainerFromItem(
        (this.datagrid.CurrentCell.Item as SomethingItem));
    
      if (Validation.GetHasError(cellItemContainer) && TryFindCildElement(cellItemContainer, out TextBox editTextBox))
      {
        // Get the property name of he binding source
        var propertyName = (editTextBox.BindingGroup.BindingExpressions.FirstOrDefault() as BindingExpression)?.ResolvedSourcePropertyName;
    
        // Use reflection to get the value of the binding source
        object value = this.datagrid.CurrentCell.Item.GetType().GetProperty(propertyName).GetValue(this.datagrid.CurrentCell.Item);
    
        // Check which ToString() to invoke
        editTextBox.Text = value is DateTime date 
          ? date.ToShortDateString() 
          : value.ToString();
    
        // Trigger validation
        Keyboard.Focus(editTextBox);
      }
      this.datagrid.CancelEdit();
    }
