    string[] result;
 
    // pass a string, and the delimiter
    result = string.Split("My simple string", " ");
    // split an existing string by delimiter only
    string foo = "my - string - i - want - split";
    result = foo.Split("-");
    // you can even pass the split options param. when omitted it is
    // set to StringSplitOptions.None
    result = foo.Split("-", StringSplitOptions.RemoveEmptyEntries);
