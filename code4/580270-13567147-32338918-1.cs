        static void Main()
        {
        	foreach (string line in File.ReadAllLines("text.txt"))
        	{
        	    string[] words = line.Split(' ');
        	    foreach (var word in words)
        	    {
        	         Console.WriteLine(word.Lenght > 7 ? ">7": "<=7");
        	    }
        	}
       }
