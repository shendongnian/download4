    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
    public static string SubmittedQuantity
    {
        get => _SubmittedQuantity;
        set
        {
            if (value != _SubmittedQuantity)
            {
                _SubmittedQuantity = value;
                StaticPropertyChanged?.Invoke(null,
                    new PropertyChangedEventArgs(nameof(SubmittedQuantity)));
            }
        }
    }
