    public class Utilities 
    {
        public static TReturn GetValueFromUsing<T,TReturn>(Func<T,TReturn> func) where T : IDisposable, new()
        {
            TReturn result = default(TReturn)
            using(var instance = new T())
                result = func(instance);
            return result;
        }
    }
