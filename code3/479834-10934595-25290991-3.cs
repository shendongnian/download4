    di.GetFiles("*.pdf").ForEach(action); 
    public static class Hlp
    {
     static public void ForEach<T>(this IEnumerable<T> items, Action<T> action)
     {
       foreach (var item in items)
         action(item);
     }
    }
