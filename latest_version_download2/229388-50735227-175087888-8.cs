    public class MyComparer<T> : IComparer<IEnumerable<T>> {
      public int Compare(IEnumerable<T> x, IEnumerable<T> y) {
        if (Object.ReferenceEquals(x, y))
          return 0;
        else if (null == x)
          return -1;
        else if (null == y)
          return 1;
        Comparer<T> comparer = Comparer<T>.Default;
        using (var en_x = x.GetEnumerator()) {
          using (var en_y = y.GetEnumerator()) {
            if (!en_x.MoveNext()) 
              if (!en_y.MoveNext())
                return 0;
              else
                return 1;
            else if (en_y.MoveNext())
              return -1;
            if (comparer != null) {
              int result = comparer.Compare(en_x.Current, en_y.Current);
              if (result != 0)
                return result;
            }
          }
        }
        return 0;
      }
    }
