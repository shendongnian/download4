    public class Inventory
    {
    	public int id {get;set;}
    	[ConcurrencyCheck]
    	public int availQty {get;set;}
    }
    
    try
    {
    	//your code...
    	await _context.SaveChangesAsync();
        //so, instead of:
    	//update Inventorys
    	//set availQty = 90 where id = 1
        //will be:
    	//update Inventorys
    	//set availQty = 90 where id = 1 and availQty = 100
    	//i.e, if availQty has been already decrement, no rows will be affected 
    	//and exception below will be thrown.
    }
    catch(DbUpdateConcurrencyException)
    {
    	//TODO: reread value from database, updated by another request, and decrement it again
    }
