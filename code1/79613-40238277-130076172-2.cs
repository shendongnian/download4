    public IEnumerable<Type> FindDerivedTypes( Assembly assembly, Type baseType )
    {
            TypeInfo baseTypeInfo = baseType.GetTypeInfo();
            bool isClass = baseTypeInfo.IsClass, isInterface = baseTypeInfo.IsInterface;
            return
                from type in assembly.DefinedTypes
                where isClass ? type.IsSubclassOf( baseType ) :
                      isInterface ? baseTypeInfo.ImplementedInterfaces.Contains( type.AsType() ) : false
                select type.AsType();
    }
