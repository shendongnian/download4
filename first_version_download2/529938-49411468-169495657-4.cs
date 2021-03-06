    public class IgnoreDefaultPropertiesConvention<T> : IMemberMapConvention
    {
    	public string Name  => $"Ignore Default Properties for {typeof(T)}";
    
    	public void Apply(BsonMemberMap memberMap)
    	{
    		if (typeof(T) == memberMap.ClassMap.ClassType)
    		{
    			memberMap.SetIgnoreIfDefault(true);
    		}
    	}
    }
