        namespace System.Collections.Generic
        {
            public static class Extensions
            {
                public static int Replace<T>(this IList<T> source, T oldValue, T newValue)
                {
                    if (source == null)
                        throw new ArgumentNullException("source");
                    var index = source.IndexOf(oldValue);
                    if (index != -1)
                        source[index] = newValue;
                    return index;
                }
                public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
                {
                    if (source == null)
                        throw new ArgumentNullException("source");
                    return source.Select(x => EqualityComparer<T>.Default.Equals(x, oldValue) ? newValue : x);
                }
            }
        }
    
