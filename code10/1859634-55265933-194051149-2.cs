[Table(Name = "Products")]
public class ProductEntity
{
    // your other columns...
    [NotMapped]
    public bool ActiveListing {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable
            return result;
        }
    }
}
but if you need to store it, change the name of ActiveListing property, then manually assign to the final ActiveListing property before you will create or update the record. Example:
[Table(Name = "Products")]
public class ProductEntity
{
    // your other columns...
    [NotMapped]
    public bool CalculateActiveListing
    {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable
            return result;
        }
    }
    public bool ActiveListing { get; set; }
}
sorry, my bad english.
