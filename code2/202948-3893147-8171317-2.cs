    for(;;)
    {
        Console.Write("Enter your selection (1, 2, or 3): ");
        string s = Console.ReadLine();
        int n = Int32.Parse(s);
    
        switch (n)
        {
            case 1:
               Console.WriteLine("Current value is {0}", 1);
               break;
            case 2:
               Console.WriteLine("Current value is {0}", 2);
               break;
            case 3:
                Console.WriteLine("Current value is {0}", 3);
                break;
            default:
               Console.WriteLine("Sorry, invalid selection.");
               break;
            }
    
     }
