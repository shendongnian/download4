    public static class MyExtensions
    {
        public static void SetSessionObject(this object o) 
        {
            Session["SessionObject"] = value;
        }
        public static SessionObject GetSessionObject(this object o)
        {
            return Session["SessionObject"] as SessionObject;
        }
    }
