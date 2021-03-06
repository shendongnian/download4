    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value is int)
        {
            int iValue = (int)value;
            if (iValue == 0) 
            {
                return new ValidationResult(false, "No ID number");
            }
            return new ValidationResult(true, null);
        }
        else if (value is string)
        { 
            if (String.IsNullOrEmpty(value.ToString()) || value == "0")
            { 
                return new ValidationResult(false, "No ID number"); 
            }
        }
        return new ValidationResult(true, null);
    }
