    namespace MakePi
    {
        public  class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(MakePi(4));
                Console.ReadLine();
    
            }
            public static int[] MakePi(int n)
            {
                double pi = Math.PI;
                string piString = pi.ToString().Remove(1, 1);
				
				Console.WriteLine(piString);
				
                int[] newPi = new int[n];
    
                for (int i = 0; i < n; i++)
                {
					//Console.WriteLine("i:"+i);
                    newPi[i] = (int)char.GetNumericValue(piString[i]);
                    Console.Write(newPi[i]);                    
                }
                return newPi;
            }
        }
    }  
