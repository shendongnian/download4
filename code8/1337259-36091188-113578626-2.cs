      static void Main(string[] args)
        {
            String string1 = "";
            String string2 = "";
            if (String.IsNullOrEmpty(string1.Trim()) && String.IsNullOrEmpty(string2.Trim()))
            {
                Console.WriteLine("Both the string Null & equal");
            }
            else if (!String.IsNullOrEmpty(string1.Trim()) && String.IsNullOrEmpty(string2.Trim()))
            {
                Console.WriteLine("String2 is null and string1 is not!");
            }
            else if (String.IsNullOrEmpty(string1.Trim()) && !String.IsNullOrEmpty(string2.Trim()))
            {
                Console.WriteLine("String1 is null and string2 is not!");
            }
            else {
                Console.WriteLine("both strings are not null!");
            }
        }
