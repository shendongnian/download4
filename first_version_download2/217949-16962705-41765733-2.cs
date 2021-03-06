    // custom matchers
    mock.Setup(foo => foo.Submit(IsLarge())).Throws<ArgumentException>();
    ...
    public string IsLarge() 
    { 
      return Match.Create<string>(s => !String.IsNullOrEmpty(s) && s.Length > 100);
    }
