    void Main()
    {
    	string str1 = "ðə ɻɛd fɑks ɪz hʌŋgɻi";
    	string str2 = "ðæt ɪt foks ɪn ðʌ sʌn ɻe͡i";
    	Console.WriteLine(StringCompare(str1,str2)); //34.6153846153846
    	Console.WriteLine(StringCompare("same","same")); //100
    	Console.WriteLine(StringCompare("","")); //100
    	Console.WriteLine(StringCompare("","abcd")); //0  
    }
    
    static double StringCompare(string a, string b)
    {
    	if (a.Length == 0)
    	{
    		if (b.Length == 0)
    			return 100; //Both empty strings.
    		return 0; 
    	}
    	double maxLen = a.Length > b.Length ? a.Length: b.Length;
    	int minLen = a.Length < b.Length ? a.Length: b.Length;
    	int sameCharAtIndex = 0;
    	for (int i = 0; i < minLen; i++)
    	{
    		if (a[i] == b[i])
    		{
    			sameCharAtIndex++;
    		}
    	}
    	return sameCharAtIndex / maxLen * 100;
    }
