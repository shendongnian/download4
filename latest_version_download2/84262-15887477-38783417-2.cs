    public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.Register( // Register instead of RegisterAttached
            "SelectedItems",
            typeof(ObservableCollection<object>), 
            typeof(MultiSelectComboBox), 
            new PropertyMetadata(SelectedItemsPropertyChanged)); // no default value
