private static volatile PrintStringDataBuilder _instance = null;
private static object _lockObject = new object();
public static PrintStringDataBuilder GetInstance()
{
    if(_instance == null)
    {
         lock(_lockObject)
         {
              if(_instance == null)
              {
                 _instance = new PrintStringDataBuilder();
              }
         }
    }
    return _instance;
}
