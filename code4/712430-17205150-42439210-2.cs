    public bool ValidateDates(params string[] dates)
    {
        return dates.All( d => Validate(d));
    }
    
    public bool Validate(Stuff stuff, out string message)
    {
       
        ValidateDates(stuff.Date1,stuff.Date2,stuff.Date3);
    }
