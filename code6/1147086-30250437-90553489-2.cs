    public class MyTypeResolver
    {
    	public static int Foo;    
    	public static IMyType ResolveType()
    	{
       		if (Foo % 2 == 0)
        		return new MyEvenType();
        	return new MyOddType();
        }
    }
