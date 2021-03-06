    public class Parent : IDisposable
    {
        private static List<Parent> objList = new List<Parent>();
        private static IReadOnlyList<Parent> readOnlyList = new ReadOnlyCollection<Parent>(objList);
        public static IEnumerable<Parent> InstanceList { get { return readOnlyList; } }
        private bool _isDisposed = false;
        public bool IsDisposed {  get { return _isDisposed;  } }
        public Parent()
        {
            objList.Add(this);
        }
        ~Parent()
        {
            OnDispose(false);
        }
        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(bool disposing)
        {
            objList.Remove(this);
            _isDisposed = true;
        }
    }
    public class Child : Parent
    {
        private static IEnumerable<Child> _instances = Parent.InstanceList.Where((p) => typeof(Child).IsAssignableFrom(p.GetType())).Select((p) => (Child)p);
        public new static IEnumerable<Child> InstanceList { get { return _instances; }}
        public Child() : base()
        {
        }
    }
       
