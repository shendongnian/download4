    // ...
    do
    {
        int intUserNum = int.Parse(Console.ReadLine());
        if (intUserNum == intRandomNum)
            Console.WriteLine("You got it! Great job!");
        if (intUserNum < intRandomNum)
        {
            Console.WriteLine("Too low! Try Again.");
            Console.ReadLine();
        }
        if (intUserNum > intRandomNum)
        {
            Console.WriteLine("Too high! Try again.");
            Console.ReadLine();
        }
    } while (intUserNum != intRandomNum);
