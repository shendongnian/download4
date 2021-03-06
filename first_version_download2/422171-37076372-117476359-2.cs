    using System;
    using System.Numerics;
					
    public class Program
    {
	    public static void Main()
        {
            BigInteger x = BigInteger.Parse("2697841949839130393229424953460693359375000000");
            BigInteger y = BigInteger.Parse("2");
		    int counter = 0;
            BigInteger remainder = 0;
	    	do{
		    	BigInteger.DivRem(x, y, out remainder);
		    	if(!remainder.IsZero)
		    		break;
			
		    	x = x/y;
		    	counter++;
	    	} while (true);
		
	    	Console.WriteLine(counter);
	    }
    }
