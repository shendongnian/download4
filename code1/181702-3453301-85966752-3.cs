    public static class MiscExtensions
    {
        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLast<T>(IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
    }
