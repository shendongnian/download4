    // This is the group that you're replace --------------|
    //                                                     V                                                           
    string pattern = "(define\\s*\\(\\s*'\\w*'\\s*,\\s*')(\\w*)('\\s*\\)\\s*;)";
            
    string string1 = "define ('KEY', 'VALUE');";
    string string2 = "define    ('KEY'  , 'VALUE');";
    string string3 = "define('KEY', 'VALUE'        );";
    string string4 = "define('KEY',       'VALUE')  ;";
    Console.WriteLine(Regex.Replace(string1, pattern, "$1Hello$3"));
    Console.WriteLine(Regex.Replace(string2, pattern, "$1ChangeMe$3"));
    Console.WriteLine(Regex.Replace(string3, pattern, "$1GoodBye$3"));
    Console.WriteLine(Regex.Replace(string4, pattern, "$1ThisWorked$3"));
