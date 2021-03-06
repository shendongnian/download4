    namespace LookupSample
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                List<string> names = new List<string>();
                names.Add("Smith");
                names.Add("Stevenson");
                names.Add("Jones");
    
                ILookup<char, string> namesByInitial = names.ToLookup((n) => n[0]);
    
                // count the names
                Console.WriteLine("J's: {0}", namesByInitial['J'].Count()); // 1
                Console.WriteLine("S's: {0}", namesByInitial['S'].Count()); // 2
                Console.WriteLine("Z's: {0}", namesByInitial['Z'].Count()); // 0, does not throw
            }
        }
    }
