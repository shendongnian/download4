    public class Inventory : MonoBehaviour
    {
        public List<InventoryItem> itemsGOInInventory = new List<InventoryItem>();
        public void AddItem(GameObject itemToBeAdded)
        {
            itemsGOInInventory.Add(itemToBeAdded.GetComponent<InventoryItem>());
            Destroy(itemToBeAdded);
        }
    //...
    }
