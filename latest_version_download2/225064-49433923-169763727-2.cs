    public class Class1 
    {
         public int Id { get; set; }
    
         public virtual NestedProp NestedProp { get; set; } = new NestedProp();
    }
    
    public class NestedProp
    {
         public int Id { get; set; }
         public decimal Prop1 { get; set; }
    }
