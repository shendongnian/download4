    class Person {
      public string Name { get; set; }
      public string Surname { get; set; }
      public int StatusId { get; set; }
      public List<ReferenceItem> Statuses { get; set; }
    
      public Person(IReferenceDataProvider provider) {
         Statuses = provider.GetData(DataType.ClientStatus);
      }
    }
