    	public static void Main(string[] args)
		{
		    var data = new MyData();
		    data.Fractions = new MyCollection();
		    data.Fractions.Add(new MyFrac { N = "1", D = "2" });
		    data.Fractions.Add(null);
		    data.Fractions.Add(null);
		    data.Fractions.Add(new MyFrac { N = "3", D = "6" });
		
		    var serializer = new XmlSerializer(typeof(MyData));
		    StringBuilder sb = new StringBuilder();
		
		    using (var writer = new StringWriter(sb))
		    {
		        serializer.Serialize(writer, data);
		    }
		
		    // Dump XML
		    Console.WriteLine(sb.ToString());
		
		    using (var reader = new StringReader(sb.ToString()))
		    {
		        var data2 = (MyData)serializer.Deserialize(reader);
		        foreach (var element in data2.Fractions) {
		        	Console.WriteLine(element);
		        }
		    }
		    
		    Console.ReadLine();
		}
