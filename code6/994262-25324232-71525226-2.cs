    public class MyClass {
      private readonly List<Item> q = new List<Item>();
      private readonly List<Item> checkedItems = new List<Item>();
    
      public ICollection<Item> Q
      {
         get { return q; }
      }
    
      public ICollection<Item> CheckedItems
      {
         get { return checkedItems; }
      }
    
      public void TransferItems() {
        // todo:
      }
    }
    
    public class Item { }
