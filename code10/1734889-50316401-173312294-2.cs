    class Person
    {
       string Name { get; set; }
       string Lastname { get; set; }
    }
    List<Person> list = new List<Person>();    
    
    for (int i = 0; i < 500; i++)
    {
       var name = Imie[losuj.Next(0, 7)];
       var lastname = Nazwisko[losuj.Next(0, 7)];
       var presentInList = list.Where(p => p.Name == name && p.Lastname == lastname).First();
       if(!presentInList) 
       {
          list.Add(new Person { Name = name, Lastname = lastname});
          createNode(i.ToString(), name, lastname, losuj.Next(1, 50).ToString(), writer);
          writer.WriteEndElement();
       }     
    }
