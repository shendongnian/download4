    do  
    {
        Console.Write("Number one: ");
        Console.WriteLine("Wrong input. try again.");
    } while (!Int32.TryParse(Console.ReadLine(), out result)); // write this for all 3 inputs.
