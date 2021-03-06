    public class Person
    {
        public int Id { get; private set;}
        public string Name { get; private set;}
        public Address Address { get; private set;}
    
        // .. constructor etc
    }
    public class Address
    {
        [Key,ForeignKey("Person")]
        public int PersonId { get; private set;}
        public string Street { get; private set;}
    
        public Person Person {get; set;}
    
        // .. constructor etc
    }
