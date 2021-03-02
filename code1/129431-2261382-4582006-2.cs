    public interface IFriendly
    {
      void Greet();
    }
    
    public interface IEnemy
    {
      void Greet();
    }
    
    public class SomeGuy : IFriendly, IEnemy
    {
      //default Greeting
      public void Greet()
      {
        //...
      }
    
      //greeting when using an IFriendly reference
      public void IFriendly.Greet()
      {
        //,,
      }
    
      //greeting when using an IEnemy reference
      public void IEnemy.Greet()
      {
        //,,
      }
    }
