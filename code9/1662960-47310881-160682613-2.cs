    public static class C
    {
            private static Dictionary<TypeEnum, Func<bool> dic = new Dictionary<TypeEnum, Func<bool>() {
                 { DataType.1, A.SampleMethod },
                 { DataType.2, B.SampleMethod }
            }
            public static bool DoStuff(Enum dataType)
            {    
               return dic[dataType].Invoke();
            }
    }
