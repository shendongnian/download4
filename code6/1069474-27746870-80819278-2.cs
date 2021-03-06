    public static class MyExtensions
    {
        public static TResult IfNotNull<TSource, TResult>(this TSource source, Func<TSource, TResult> function)
            where TSource : class where TResult : class
        {
            if (source == null)
                return null;
            return function(source);
        }
    }
