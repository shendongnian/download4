    public static void Main()
    {
        for (int a = 0; a < 10; a++)
        {
            (i++).Print();
        }
    }
    static class Extensions
    {
        public static void Print(this string i)
        {
            Console.WriteLine(i);
        }
    }
