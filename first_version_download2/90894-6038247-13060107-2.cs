    // Create a new dictionary of strings, with string keys, 
    // and access it through the IDictionary generic interface.
    IDictionary<string, string> openWith = 
        new Dictionary<string, string>();
    
    // Add some elements to the dictionary. There are no 
    // duplicate keys, but some of the values are duplicates.
    openWith.Add("txt", "notepad.exe");
    openWith.Add("bmp", "paint.exe");
    openWith.Add("dib", "paint.exe");
    openWith.Add("rtf", "wordpad.exe");
