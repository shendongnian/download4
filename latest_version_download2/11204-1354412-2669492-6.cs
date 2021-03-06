    List<Type> messageTypes = new List<Type>();
    //get the assembly containing our types
    Assembly messageAssembly = Assembly.Load(...);
    //get all the types in the assembly
    Type[] types = messageAssembly.GetTypes();
    foreach(Type type in types)
    {
        //make sure we inherit from BaseMessage
        if(type.IsAssignableFrom(typeof(BaseMessage))
        {
            //check to see if the inherited type has a MessageAttribute
            object[] attribs = type.GetCustomAttribtues(typeof(MessageAttribute), true);
            if(attribs.Length > 0)
            {
                messageTypes.Add(type);
            }
        }
    }
