    using System;				
    public class Program
    {
    	public static void Main()
    	{
    		byte[] encbuff = System.Text.Encoding.UTF8.GetBytes("äöüß");
    		string enc = Convert.ToBase64String(encbuff);
    		Console.WriteLine(enc); // you get "w6TDtsO8w58="	
    	}
    }
