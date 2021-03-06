    public static class EasySession
    {
        public static string UserId
        {
            get
            {
                return Get<string>();
            }
            set
            {
                Set(value);
            }
        }
        public static string OtherVariableA
        {
            get
            {
                return Get<string>();
            }
            set
            {
                Set(value);
            }
        }
        public static <datatype> OtherVariableB
        {
            get
            {
                return Get<datatype>();
            }
            set
            {
                Set(value);
            }
        }
        static  void Set<T>(T value, [CallerMemberName] string key = "")
        {
                System.Web.HttpContext.Current.Session[key] = value;
        }
        static  T Get<T>([CallerMemberName] string key = "")
        {
            return (T)System.Web.HttpContext.Current.Session[key];
        }
    }
