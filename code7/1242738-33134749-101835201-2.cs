    public static class IEnumerableExtensions {
       public static void ForEach<T>(this IEnumerable<T> pEnumerable, Action<T> pAction) {
          foreach (var item in pEnumerable)
             pAction(item);
       }
    }
