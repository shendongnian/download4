    public static void Execute<T>(T parameters)
    {
        var type = _handlers[parameters.GetType().FullName];
        var handler = Activator.CreateInstance(type);
        type.GetMethod("Execute").Invoke(handler, new object[] { parameters });
    }
