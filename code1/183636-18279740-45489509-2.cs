     namespace InternalTest   ----This namespace in assembly One
     {
        Public class A
        {
            A ol=new A();
            Console.WriteLine(ol.x);//Output:5  
            Console.WriteLine(ol.y);//error will occured. Because protected is like Private variable
        }
        public class B
         {
            Internal int x=5;
             Protected int y=5;
          }
     }
    
