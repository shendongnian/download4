        private ObservableCollection<MyDataClass> _myDataList;
        private MyDataClass _myData;
        public ICommand CheckCommand { get; set; }
        public MainViewModel()
        {
            var list = new List<MyDataClass>
                {
                    new MyDataClass { Description = "Item 01", Quantity = 20, IsSelected = false },
                    new MyDataClass { Description = "Item 02", Quantity = 50, IsSelected = false },
                    new MyDataClass { Description = "Item 03", Quantity = 60, IsSelected = false }
                };
            MyDataList = new ObservableCollection<MyDataClass>(list);
            CheckCommand = new RelayCommand(()=> { Amount = MyDataList.Where(x => x.IsSelected).Sum(x => x.Quantity); });
        }
        public ObservableCollection<MyDataClass> MyDataList
        {
            get => _myDataList;
            set
            {
                _myDataList = value;
                OnPropertyChanged();
            }
        }
