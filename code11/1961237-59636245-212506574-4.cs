    List<MyClass> allClasses = new List<MyClass>();
    for(int i =0 ; i < 10 ; i++)
    {
       MyClass myClass = new MyClass();
       myClass.Value = i;
       allClasses.add(myClass);
    }
    public class MyClass{public int Value =0 ;}
