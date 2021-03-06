    /* The examples generates this output when run:
    0
    432123
    -1
    1/1/0001 12:00:00 AM
    1/1/1970 12:00:00 AM
    1/30/2013 12:00:00 PM
    -1
    12342.3233443
    */
    class Program
        {
        static void Main ( string[] args )
            {
            Debug.WriteLine( "blah".Parse<Int64>() );
            Debug.WriteLine( "432123".Parse<long>() );
            Debug.WriteLine( "123904810293841209384".Parse<long>( -1 ) );
            Debug.WriteLine( "this is not a DateTime value".Parse<DateTime>() );
            Debug.WriteLine( "this is not a DateTime value".Parse<DateTime>( "jan 1, 1970 0:00:00".Convert<DateTime>() ) );
            Debug.WriteLine( "2013/01/30 12:00:00".Parse<DateTime>() );
            Debug.WriteLine( "this is not a decimal value".Parse<decimal>( -1 ) );
            Debug.WriteLine( "12342.3233443".Parse<decimal>() );
            }
        }
    static public class Extensions
        {
        static private Dictionary<Type,MethodInfo> s_methods = new Dictionary<Type, MethodInfo>();
        static public T Parse<T> ( this string value ) where T : struct
            {
            return value.Parse<T>( default( T ) );
            }
        static public T Parse<T> ( this string value, T defaultValue ) where T : struct
            {
            // *EDITED* to cache the Reflection lookup--NOT thread safe
            MethodInfo m = null;
            if ( s_methods.ContainsKey( typeof( T ) ) )
                {
                m = s_methods[ typeof( T ) ];
                }
            else
                {
                m = typeof( T ).GetMethod(
                     "TryParse"
                     , BindingFlags.Public | BindingFlags.Static
                     , Type.DefaultBinder
                     , new[] { typeof( string ), typeof( T ).MakeByRefType() }
                     , null
                     );
                s_methods.Add( typeof( T ), m );
                }
            var args = new object[] { value, null };
            if( (bool)m.Invoke( null, args ))
                {
                return (T) args[ 1 ];
                }
            return defaultValue;
            }
        }
