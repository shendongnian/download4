    if (Char.IsControl(ch))
    {
        // The value is not needed until you know its a control char
        int val = (int)Char.GetNumericValue(ch);
        if (mapping.ContainsKey(val))
        {
            // You know what the control char is, so output its name
            outStr.Append(mapping[val]);
        }
        else
        {
           // Because you might have missed a control char in your dictionary of names
           // So output its hex value
           outStr.AppendFormat("<{0}>", val.ToString("X"));  
        }
    }
    else
    {
        // Char is not a control char
        outStr.Append(ch);
    }
    
