    public abstract class Base
    {
        private testEntities db = new testEntities();
        public List<int> XList = new List<int>();
        public List<int> YList = new List<int>();
        public void GetAllInfo()
        {
            // Get the data from a database and add to a list (the same as in class A)
            XList = db.Table1.ToList();
            YList = db.Table2.ToList();
        }
        public abstract void DoStuff();
    }
    public class A: Base
    {
        public override void DoStuff()
        {
            // Do Stuff with XList and YList
        }
    }
    public class B: Base
    {
        public override void DoStuff()
        {
            // Do ddifferent stuff with XList and YList then in class A
        }
    }
