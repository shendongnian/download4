       static void Main(string[] args)
       {
          clsPerson p=new clsPerson();
          p.FirstName = "Jeff";
          p.MI = "A";
          p.LastName = "Price";
          System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
          x.Serialize(Console.Out, p);
          Console.WriteLine();
          Console.ReadLine();
       }
