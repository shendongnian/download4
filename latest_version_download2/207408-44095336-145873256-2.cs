    public static int GetInt()
    {
        int X;
        String Result = Console.ReadLine();
        while(!Int32.TryParse(Result, out X))
        {
           Console.WriteLine("Not a valid Int, try again!");
           Result = Console.ReadLine();
        }
        return X;
    }
