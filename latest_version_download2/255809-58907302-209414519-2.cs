    class Printable
    {
        protected readonly Action _action;
        public Printable(Action printAction)
        {
            _action = printAction;
        }
        public void Print()
        {
            _action();
        }
    }
    void CallPrint<T>(T obj) where T : Printable
    {
        obj.Print();
    }
    var wrapper = new Printable( ()=> foo.Print() );
    CallPrint(wrapper)(
