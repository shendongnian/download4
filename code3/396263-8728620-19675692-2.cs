    public class MyClass{
      private static int instanceCounter = 0;
    
      private int instanceNumber;
      public MyClass(){
        instanceNumber = instanceCounter;
        Interlocked.Increment(instanceCounter);
      }
      ...
    }
