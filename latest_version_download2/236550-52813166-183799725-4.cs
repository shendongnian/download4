    private int _currentNumber;
    public int CurrentNumber
    {
        get
        {
            return _currentNumber;
        }
        set
        {
            _currentNumber = value;
            OnPropertyChanged(nameof(CurrentNumber));
            // or (depending on if the Method uses the [CallerMemberName] attribute)
            OnPropertyChanged();
        }
    }
    
    public void CountUp()
    {
        // current = Nummer.Count + 1;
        CurrentNumber += Current + 1;
        Nummer.Add(new NumberViewModel { Num = CurrentNumber });
    }
    public void Multiply(int multiplyParameter)
    {
        CurrentNumber = multiplyParameter * multiplyParameter;
        Nummer.Add(new NumberViewModel { Num = CurrentNumber});
    }
