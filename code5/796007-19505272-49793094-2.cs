    public static string ToIntString<T>(this T enumVal) where T : struct, IConvertible, IComparable, IFormattable
    {
       TestGenericEnum<T>();
       return (Convert.ToInt32(enumVal).ToString();
    }
    
    private static void TestGenericEnum<T>()
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be of type System.Enum");
    }
  
