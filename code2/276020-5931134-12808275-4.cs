     class MethodComparer : IEqualityComparer<MethodInfo>
        {
            public bool Equals(MethodInfo x, MethodInfo y)
            {
                return GetHashCode(x) == GetHashCode(y);
            }
    
            public int GetHashCode(MethodInfo obj)
            {
                int hash = obj.Name.GetHashCode();
                foreach (var param in obj.GetParameters())
                    hash ^= param.ParameterType.GetHashCode();
                if (obj.IsGenericMethodDefinition)
                {
                    hash ^= obj.GetGenericArguments().Length.GetHashCode();
                }
                else if (obj.IsGenericMethod)
                {
                    foreach (var t in obj.GetGenericArguments())
                        hash ^= t.GetHashCode();
                }
            
                return hash;
            }
        }
    
        static class Ext
        {
            public static MethodInfo[] MyGetMethods(this Type t)
            {
                if (t == null)
                    return new MethodInfo[] { };
    
                var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    
                var baseMethods = from m in t.BaseType.MyGetMethods()
                        where !methods.Contains(m, new MethodComparer())
                        select m;
    
                return methods.Concat(baseMethods).ToArray();
            }
        }
    
    var m = new DerivedClassWithGenericMethod();
    foreach (var method in m.GetType().MyGetMethods())
        Debug.WriteLine(method.Name);
