    public class Analytics
    {
       public long UserExpId { get;set;}
       public string UserExpStatus { get; set;}
       public string Category { get;set;}
       public int Value {get; set;}
    
       [XmlAttribute]
       public DateTime Timestamp { get; set; }
    }
