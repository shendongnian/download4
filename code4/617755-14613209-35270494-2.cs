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
            Debug.WriteLine( "blah".Convert<Int64>() );
            Debug.WriteLine( "432123".Convert<long>() );
            Debug.WriteLine( "123904810293841209384".Convert<long>( -1 ) );
            Debug.WriteLine( "this is not a DateTime value".Convert<DateTime>() );
            Debug.WriteLine( "this is not a DateTime value".Convert<DateTime>( "jan 1, 1970 0:00:00".Convert<DateTime>() ) );
            Debug.WriteLine( "2013/01/30 12:00:00".Convert<DateTime>() );
            Debug.WriteLine( "this is not a decimal value".Convert<decimal>( -1 ) );
            Debug.WriteLine( "12342.3233443".Convert<decimal>() );
            }
        }
    static public class Extensions
        {
        static public T Convert<T> ( this string value )
            {
            return value.Convert<T>( default( T ) );
            }
        static public T Convert<T> ( this string value, T defaultValue )
            {
            MethodInfo m = typeof( T ).GetMethod(
                "TryParse"
                , BindingFlags.Public | BindingFlags.Static
                , Type.DefaultBinder
                , new[] { typeof( string ), typeof( T ).MakeByRefType() }
                , null
                );
            var args = new object[] { value, null };
            if( (bool)m.Invoke( null, args ))
                {
                return (T) args[ 1 ];
                }
            return defaultValue;
            }
        }
