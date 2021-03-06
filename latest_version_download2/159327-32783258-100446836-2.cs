      public static class Sequences {
        // Instead of reinveting the wheel (ISequence etc.), let's return  
        // IEnumerable<long> which is specially designed for such a cases
        public static IEnumerable<long> Fibonacci(long first, long second) {
          yield return first;
          yield return second;
    
          while (true) {
            long result = first + second;
    
            first = second;
            second = result;
    
            yield return result;
          }
        }
      }
    
      ...
      // Test: 10 first Fibonacci numbers:
      // 1, 2, 3, 5, 8, 13, 21, 34, 55, 89
      Console.Write(String.Join(", ", Sequences.Fibonacci(1, 2).Take(10)));
      ...
    
      // Now having Fibonacci as IEnumerable<long>
      // you can easily answer a lot of questions via Linq:
      long result = Sequences.Fibonacci(1, 2)
        .TakeWhile(item => item < 4000000) // up to 4 millions
        .Where(item => item % 2 == 0)      // take even items only
        .Sum();                            // sum them up
