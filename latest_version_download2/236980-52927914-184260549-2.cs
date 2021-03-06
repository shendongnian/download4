       using System.Linq; // We are going to use .ToArray()
       ...
       private static int[] ReadUniqueNumbers(int count) {
         HashSet<int> numbers = new HashSet<int>();
         Console.WriteLine($"Enter {count} unique numbers"); 
         while (numbers.Count < count) {
           int number = 0;
           if (!int.TryParse(Console.ReadLine(), out number))  
             Console.WriteLine("Syntax error. Not a valid integer value. Try again.");
           else if (!numbers.Add(number))
             Console.WriteLine("Hold on, you already entered that number. Try again."); 
         }
         // Or if you want ordered array
         // return numbers.OrderBy(item => item).ToArray(); 
         return numbers.ToArray(); 
       }
    
    ...
       int[] number = ReadUniqueNumbers(5);
