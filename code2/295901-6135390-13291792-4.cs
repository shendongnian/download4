    namespace SameAssembly
    {
        public class A 
        {
           protected void abc()
           {
           }
        }
        
        private class B : A 
        {
           void F() 
           {
              A a = new A();  
              B b = new B();  
              a.abc();   // Error
              b.abc();   // OK
           }
        }
    }
