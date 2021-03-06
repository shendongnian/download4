    public T CreateAndPopulate<T>(IEnumerable<KeyValueStore> propStore,
                                  IDictionary<string, string> mapping = null) 
                                 where T:class,new()
    {
    	
    	T item=new T();
    	var type=typeof(T);
    	foreach(var kvs in propStore)
    	{
    		var propName = kvs.Key;
    		propName = mapping !=null && mapping.ContainsKey(propName) 
                           ? mapping[propName] 
                           : propName;
    		var prop = type.GetProperty(propName);
            if(prop == null) //does the property exist?
            {
                continue;
            }
    		var propMethodInfo = prop.GetSetMethod();
    		if(propMethodInfo == null) //does it have a set method?
    		{
    			continue;
    		}
            propMethodInfo.Invoke(item, new[]{ kvs.Value });
    	}
    	return item;
    }
