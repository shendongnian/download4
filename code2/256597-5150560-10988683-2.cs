            public static IEnumerable<T> Values
            {
                get
                {
                    if (nameRegistry.Count > 0)
                    {
                        return nameRegistry.Values;
                    }
                    var aField = typeof (T).GetFields(
                                            BindingFlags.Public | BindingFlags.Static)
                                        .FirstOrDefault();
                    if (aField != null)
                        aField.GetValue(null);
    
                    return nameRegistry.Values;
                }
            }
