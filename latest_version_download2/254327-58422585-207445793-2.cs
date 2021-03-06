    //Singular for the class
    class Customer
    {
      //Also Singular, as this can only take 1 name
      public string Name { get; set; }
    }
    
    //Plural, because it is a collection of Customer Instances.
    List<Customer> Customers = new List<Customer>()
    {
      new Customer {Name = "Tanveer"},
      new Customer {Name = "Nabila"},
      new Customer {Name = "Suraj"}
    };  
