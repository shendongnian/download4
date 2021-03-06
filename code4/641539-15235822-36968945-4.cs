    [Route("/events", "GET")]
    public class AllEvents {}
    
    [Route("/events", "POST")]
    public class CreateEvent 
    {
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
    }
    
    [Route("/events/{Id}", "GET")]
    public class Events 
    {
       public int Id { get; set; }
    }
    
    [Route("/events/{Id}", "PUT")]
    public class UpdateEvent
    {
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
    }
