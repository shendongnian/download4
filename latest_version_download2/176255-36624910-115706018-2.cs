    static void Main(string[] args)
        {
            float number;
            var success = Single.TryParse(Console.ReadLine(), number);
            if(success)
            {
                float gravity = (number * 0.17f);
                Console.WriteLine(gravity.ToString("F3"));
            }
            else
            {
                Console.WriteLine("Only numbers allowed.");
            }
        }
