    Console.WriteLine("Enter a number between 2 and 12");
    int x = int.Parse(Console.ReadLine());
    
    bool isValid = false;
    for(int p=2; p<13; p++)
    {
        if(x == p)
        {
            isValid = true;
            break;
        }
    }
