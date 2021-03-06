cs
var invoices = new List<Invoice>();
var result = invoices.GroupBy(i => new InvoiceHeader
{
	DocumentDate = i.DocumentDate,
	DocumentNumber = i.DocumentNumber,
	DocumentReference = i.DocumentReference
}).ToDictionary(g => g.Key, g => g.Select(i => new InvoiceHierarchi
{
	Certificate = i.Certificate,
	SerialNumber = i.SerialNumber,
	ProductCode = i.ProductCode,
	Description = i.Description
}).ToList());
Another option is to use [`ToLookup`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolookup?view=netframework-4.8#System_Linq_Enumerable_ToLookup__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Func___0___2__) method
cs
var anotherResult = invoices.ToLookup(i => new InvoiceHeader
	{
		DocumentDate = i.DocumentDate,
		DocumentNumber = i.DocumentNumber,
		DocumentReference = i.DocumentReference
	},
	i => new InvoiceHierarchi
	{
		Certificate = i.Certificate,
		SerialNumber = i.SerialNumber,
		ProductCode = i.ProductCode,
		Description = i.Description
	});
`Lookup` represents a collection of keys each mapped to one or more values. To properly use `InvoiceHeader` as a `Dictionary` key you should override `GetHashCode()` and `Equals()` method for this class, or implelement `IEquatable<T>` interface
cs
public class InvoiceHeader : IEquatable<InvoiceHeader>
{
	public string DocumentNumber { get; set; }
	public DateTime? DocumentDate { get; set; }
	public string DocumentReference { get; set; }
	public override int GetHashCode()
	{
		return DocumentNumber.GetHashCode() ^ DocumentDate.GetHashCode() ^ DocumentReference.GetHashCode();
	}
	public bool Equals(InvoiceHeader other)
	{
		if (ReferenceEquals(null, other))
			return false;
		if (ReferenceEquals(this, other))
			return true;
		return DocumentNumber == other.DocumentNumber && 
			   Nullable.Equals(DocumentDate, other.DocumentDate) &&
			   DocumentReference == other.DocumentReference;
	}
	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((InvoiceHeader)obj);
	}
}
