    System.Console.Write("Please input the kilogram price of candy: ");
    decimal pricePerKilo = decimal.Parse(System.Console.ReadLine());
    System.Console.Write("Please input the money allocated for candy ");
    decimal amountAllocatedForCandy = decimal.Parse(System.Console.ReadLine());
    System.Console.WriteLine("With the amount of money you input you would get " + (amountAllocatedForCandy / pricePerKilo) + " kilos of candy.");
    System.Console.Read();
