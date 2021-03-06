    internal class Program
    {
        private static void Main()
        {
            BaseClass bc = new BaseClass(); // outputs xxx.BaseClass
            BaseClass dc = new DerivedClass(); // outputs xxx.DerivedClass
        }
    }
    
    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine($"{GetType()}");
        }
    }
    
    public class DerivedClass: BaseClass
    {
        // default constructor calls base constructor
        // and `this` object refers to DerivedClass instance
    }
