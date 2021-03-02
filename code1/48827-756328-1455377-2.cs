    public static class IEnumerableExtensions
    {
      public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
      {
        if (source == null)
          throw new ArgumentNullException("source");
    
        return PermutationsImpl(source, new T[0]);
      }
    
      private static IEnumerable<IEnumerable<T>> PermutationsImpl<T>(IEnumerable<T> source, IEnumerable<T> prefix)
      {
        if (source.Count() == 0)
          yield return prefix;
    
        foreach (var x in source)
          foreach (var permutation in PermutationsImpl(source.Where(t => !t.Equals(x)),
                                                       prefix.Union(source.Where(t => t.Equals(x)))))
            yield return permutation;
      }
    }
