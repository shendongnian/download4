    string input = "The name of my dog is %x% and he has %y% years old.";
    // The Regex pattern: \w means "any word character", eq. to [A-Za-z0-9_]
    // We use parenthesis to identify a "group" in the pattern.
    string pattern = "%(\w)%";     // One-character variables
    //string pattern ="%(\w+)%";  // one-or-more-character variables
    
    // returns an IEnumerable
    var matches = Regex.Matches(input, pattern);
    
    foreach (Match m in matches) { 
         Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
         var variableName = m.Groups[1].Value;
    }
    
