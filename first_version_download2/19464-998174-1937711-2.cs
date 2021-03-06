    private int _maximumLength;
    private T _value;
    private string _propertyName;
    public Field(string propertyName, int maximumLength)
    {
        _propertyName = propertyName;
        _maximumLength = maximumLength;
    }
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value.ToString().Length > _maximumLength)
            {
                throw new ArgumentException(string.Format("{0} cannot exceed {1} in length.", _propertyName, _maximumLength));
            }
            else
            {
                _value = value;
                OnPropertyChanged(_propertyName);
            }
        }
    }
}
