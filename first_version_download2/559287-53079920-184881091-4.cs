    abstract class BaseClass
    {    
        public abstract void DoSomething();
    }
    
    class ChildClass1 : BaseClass{
        public override void DoSomething()
        {
            Console.WriteLine("Impl. 1");
        }
    }
    
    class ChildClass2 : BaseClass{
        public override void DoSomething()
        {
            Console.WriteLine("Impl. 2");
        }
    }
