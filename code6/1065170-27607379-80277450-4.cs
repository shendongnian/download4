    while ((line = file.ReadLine()) != null)
    {
        i++;
        if (i < 1000) continue;
        else if (i > 2000) break;
        else if (line.Contains("mySecretWord"))
        {
            System.Console.WriteLine("YES");
            System.Console.WriteLine(i);
            break;
         }
    }
