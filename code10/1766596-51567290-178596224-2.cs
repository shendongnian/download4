    DependencyPropertyDescriptor dpd;
    private void ComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        ComboBoxItem cmb = sender as ComboBoxItem;
        dpd = DependencyPropertyDescriptor
            .FromProperty(IsMouseOverProperty, typeof(ComboBoxItem));
        if (dpd != null)
            dpd.AddValueChanged(cmb, OnIsMouseOver);
    
    }
    
    private void ComboBox_Unloaded(object sender, RoutedEventArgs e)
    {
        if (dpd != null)
            dpd.RemoveValueChanged(cmb, OnIsMouseOver);
    
    }
    
    private void OnIsMouseOver(object sender, EventArgs e)
    {
        ComboBoxItem cmb = sender as ComboBoxItem;
        if (cmb.IsMouseOver)
        {
            //do something...
        }
    }
