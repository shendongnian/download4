    public class A 
    {
    	public int Value { get; set; }
    }
	public static S DoStuff<T, S>(T some, Expression<Func<T, S>> propertySelector)
	{
       if(selector.Body is MemberExpression memberExpr)
       {
		   var propertyType = memberExpr.Member;
		   var somePropertyValue = propertySelector.Compile()(some);
		
		   return somePropertyValue;
       } 
       else
           throw new ArgumentException("propertySelector", "This isn't a member expression");
	}
