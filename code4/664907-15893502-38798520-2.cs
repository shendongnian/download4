    // This code example demonstrates the Guid.NewGuid() method. 
    
    using System;
    
    class CreateGUID
    {
        public static void Main() 
        {
        Guid g;
    // Create and display the value of two GUIDs.
        g = Guid.NewGuid();
        Console.WriteLine(g);
        Console.WriteLine(Guid.NewGuid());
        }
    }
    
    /*
    This code example produces the following results:
    
    0f8fad5b-d9cb-469f-a165-70867728950e
    7c9e6679-7425-40de-944b-e07fc1f90ae7
    
    */
