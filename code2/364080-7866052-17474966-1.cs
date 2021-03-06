    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    class Foo {
    }
    
    class Foo<T> : Foo {
        private T val;
    
        public void Set(string strval) {
            var _type = typeof(T);
            val = (T)(_type.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, null, new Object[] { strval }));
        }
        override public string ToString(){
            return String.Format("{0}", val);
        } 
    }
    class Sample {
        static void Main(string[] args){
            ArrayList a = new ArrayList();
            a.Add(new Foo<float>());
            a.Add(new Foo<int>());
    
            ((Foo<float>)a[0]).Set("5.5");
            ((Foo<int>)a[1]).Set("55");
            Console.WriteLine("{0},{1}", a[0], a[1]);
        }
    }
