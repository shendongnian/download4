    class CountSpaces
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter characters,finish with a period (\".\"");
            char ch;
            int spaces = 0;
            do
            {
                ch = (char)Console.Read();
                if (ch == ' ')
                {
                    spaces++;
                }
            } while (ch != '.');
            Console.WriteLine("Number of spaces counted = {0}", spaces);
            Console.ReadKey();
        }
    }
