    public interface IEngine
    {
        public bool TryGetCabability<T>(out T capability);
    }
    
    public interface ICapability1
    {
        void Foo();
    }
    
    public class Engine1 : IEngine, ICapability1
    {
        public bool TryGetCabability<T>(out T capability)
        {
            if (typeof(T) == typeof(ICapability1))
            {
                capability = (T)(object)this;
                return true;
            }
            capability = default(T);
            return false;
        }
        
        public void Foo()
        {
            //...
        }    
    }    
    
    public class App1
    {
        public void Do()
        {
            IEngine1 e = new Engine1();
            ICapability1 cap1;
            if (e.TryGetCabability(out cap1))
            {
                cap1.Foo();
            }
        }
    }
