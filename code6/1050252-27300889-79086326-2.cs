    public void SetProperties(object source, object target)
    {
        var type = target.GetType();
        foreach (var prop in source.GetType().GetProperties())
        {
            var propGetter = prop.GetGetMethod();
            var propSetter = type.GetProperty(prop.Name).GetSetMethod();
            var valueToSet = propGetter.Invoke(source, null);
            propSetter.Invoke(target, new[] { valueToSet });
        }
    }
