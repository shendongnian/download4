    using System.Diagnostics;
    ....
 
    Stopwatch sw = new Stopwatch();
        
    sw.Start();
    // Code you want to time...
    // Note: for averaged accuracy (without other OS effects), 
    //       run timed code multiple times in a loop 
    //       and then divide by the number of runs.
    
    sw.Stop();
    
    Console.WriteLine("Took " + sw.ElapsedTicks + " Ticks");
