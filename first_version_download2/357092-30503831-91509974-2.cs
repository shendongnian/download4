    var guids = Enumerable.Range(1, 1600000).Select(_ => Guid.NewGuid().ToString().ToUpper()).ToList();
    var delimiters = "-".ToCharArray();
    
    var w = Stopwatch.StartNew();
    var x = guids.Select(guid => guid.Split(delimiters)[0].ToLower()).Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 1.60 seconds 
    
    w = Stopwatch.StartNew();
    var y = guids.Select(guid => guid.Split(delimiters)[0].ToLower()).AsParallel().Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 2.00 seconds 
    
    w = Stopwatch.StartNew();
    var z = guids.AsParallel().Select(guid => guid.Split(delimiters)[0].ToLower()).Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 1.30 seconds 
