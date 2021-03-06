    ...
    public ViewModelConstructor(...)
    {
        ...
        SelectionChangedCommand = new DelegateCommand<List<myType>>(SelectionChangedExecute);
        ...
    }
    ...
    public List<myType> ItemsForListView1 {get; private set} // Implement INotifyPropertyChanged here
    public List<myType> ItemsForListView1 {get; private set} // Implement INotifyPropertyChanged here
    ...
    public ICommand SelectionChangedCommand { get; private set; }
    private void SelectionChangedExecute(List<myType> parameter)
    {
        ItemsForListView1 = parameter.Where((x) => x.myProp > 0).ToList(); 
        ItemsForListView2 = parameter.Where((x) => x.myProp < 0).ToList();
    }
    ...
