    public ActionMethod CreateCustomer(string custName)
    {
        if (IsAcceptableRange(custName))
        { 
           //continue
        }
    }
    public bool IsAcceptableRange(string input)
    {
       Regex alphaNumericPattern=new Regex("[^a-zA-Z0-9]");
       return !alphaNumericPattern.IsMatch(input); 
    }
