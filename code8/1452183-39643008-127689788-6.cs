    public RelayCommand<SomeClass> DownloadCommand { get; set; }
    ...
    DownloadCommand = new RelayCommand<SomeClass>(DownloadExecute);
    ...
    private voir DownloadExecute(SomeClass item)
    {
        ...
    }
