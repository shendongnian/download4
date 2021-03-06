    using System;
    
    namespace CloneImplDemo
    {
        // dummy data class
        class DeepDataT : ICloneable 
        {
            public int i;
            public object Clone() { return MemberwiseClone(); } 
        }
    
        class Base: ICloneable
        {
            protected virtual Base CloneImpl()
            { 
                // Neat: Creates the type of whatever object is calling. 
                // Also obviates the need for default constructors
                // (Neither Derived1T nor Derived2T have one.)
                return (Base)MemberwiseClone();
            }
    
            public object Clone() 
            {
                // Calls whatever CloneImpl the  
                // actual calling type implements.
                return CloneImpl();
            }
        }
    
        // Note: No Clone() re-implementation
        class Derived1T : Base
        {
            public Derived1T(int i) { der1Data.i = i; }
            public DeepDataT der1Data = new DeepDataT();
            protected override Base CloneImpl()
            {
                Derived1T cloned = (Derived1T)base.CloneImpl();
                cloned.der1Data = (DeepDataT)der1Data.Clone();
                return cloned;
            }
        }
    
        // Note: No Clone() re-implementation.
        class Derived2T : Derived1T
        {
            public Derived2T(int i1, int i2) : base(i1)
            {
                der2Data.i = i2;
            }
            public string txt = string.Empty; // copied by MemberwiseClone()
            public DeepDataT der2Data = new DeepDataT();
            protected override Base CloneImpl()
            {
                Derived2T cloned = (Derived2T)base.CloneImpl();
                // base members have been taken care of in the base impl.
                // we only add our own stuff.
                cloned.der2Data = (DeepDataT)der2Data.Clone();
                return cloned;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var obj1 = new Derived2T(1,2);
                obj1.txt = "this is obj1";
    
                var obj2 = (Derived2T)obj1.Clone();
                obj2.der1Data.i++;
                obj2.der2Data.i++; // changes value.
                obj2.txt = "this is a deep copy"; // replaces reference.
    
                // the values for i should differ because 
                // we performed a deep copy of the DeepDataT members.
                Console.WriteLine("obj1 txt, i1, i2: " + obj1.txt + ", " + obj1.der1Data.i + ", " + obj1.der2Data.i);
                Console.WriteLine("obj2 txt, i1, i2: " + obj2.txt + ", " + obj2.der1Data.i + ", " + obj2.der2Data.i);
            }
        }
    }
