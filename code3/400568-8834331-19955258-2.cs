    var result = new Dictionary<string, Int32>();
    foreach (string line in File.ReadAllLines(@"C:\Temp\FileName.txt")){
        if(result.ContainsKey(line))
            result[line]++;
        else{
            result.Add(line, 1);
        }
    }
