    using System;
    // and others
    using MyDict = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<double>>>;
    namespace ConsoleApp1
    {
        public class Program
        {
        	public static void Main()
        	{
        		var a = new MyDict();
        	}
        }
    }
