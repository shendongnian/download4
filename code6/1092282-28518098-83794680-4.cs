    //This is inside MyPageViewModel
    //Item is a ViewModel type
    public IEnumerable<Item> SelectedItems
    {
         get
         {
              //Items is ObservableCollection<Item>
              return Items.Where(x => x.IsSelected);
         }
    }
    //This is also inside MyPageViewModel
    private ObservableCollection<Item> _items = new ObservableCollection<Item>();
    public ObservableCollection<Item> Items { get { return _items; } } 
