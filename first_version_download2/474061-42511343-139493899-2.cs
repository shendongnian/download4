       using System.Linq;
       ...
       public static void Main(string[] args) {
         var result = File
           .ReadLines(@"InputData.txt")
           .Select(line => line
              .Split(new char[] { ',', ';'}, StringSplitOptions.RemoveEmptyEntries)
              .Select(item => int.Parse(item))
              .Sum())
           .Select((sum, index) => 
              $"The sum of the numbers entered at line {index + 1} is: {sum}");
         Console.Write(string.Join(Environment.NewLine, result));  
       }
