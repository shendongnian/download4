       Console.WriteLine("About to call Console.ReadLine in a loop.");
        Console.WriteLine("----");
        String s;
        do
        {
           
            s = Console.ReadLine();
            //Regex regex = new Regex(@"[\d]");
            Regex regex = new Regex("[0-9]");
            Regex regex2 = new Regex("^[a-zA-Z]");
            if (regex.IsMatch(s))
            {
                if (regex.IsMatch(s) && regex2.IsMatch(s))
                {
                    Console.WriteLine("You entered an combination of number and String = " + s.ToString());
                }
                else
                {
                    Console.WriteLine("You entered an integer = " + s.ToString());
                }
            }
            else
            {
               
                Console.WriteLine("You entered a String = " + s.ToString());
            }
        } while (s != null);
        Console.WriteLine("---");
