    public static bool init_access(string file_path)
    {
        if (!File.Exists(file_path))
        {
            return false;
        }
    
        int counter = 0;
        file_path = @"C:\Users\waqas\Desktop\TextFile.txt";
        List<string> lines = File.ReadAllLines(file_path).ToList();
        foreach (string line in lines)    
        {   
            counter++;
            Console.WriteLine(counter + " " + line);
        }
        
        return true;
    }
