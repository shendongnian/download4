    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n;
                Console.WriteLine("Enter A Number :");
                n = int.Parse(Console.ReadLine());
                if (n % 3 == 0)
                {
                    if (n % 5 == 0)
                    {
                        Console.WriteLine("This Number is Divisible by 3 and 5!");
    
                    }
                    else
                    {
                        printf("\nThe number is divisible by 3 but not by 5");
                    }
                }
    
                else
                {
                    Console.WriteLine("This Number is Not Divisible by 3");
    
                }
                    Console.ReadLine();
                }
            }
        }
    
