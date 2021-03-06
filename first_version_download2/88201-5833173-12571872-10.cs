	public class ProductRepositoryMock : IRepository<Product>
	{
		#region Fields and constructor
		private IList<Product> _productsStore;
		public ProductRepositoryMock()
		{
			_productsStore = new List<Product>();
		}
		#endregion
		#region private methods
		private int GetNewId()
		{
			return _productsStore.Max(p => p.Id) + 1;
		}
		#endregion
		public void Add(Product product)
		{
			product.Id = GetNewId();
			product.Created = DateTime.Now;
			product.Updated = DateTime.Now;
			_productsStore.Add(product);
		}
		public void Update(Product product)
		{
			var storedProduct = _productsStore.Where(p => p.Id == product.Id).FirstOrDefault();
			if (storedProduct != null)
			{
				foreach (var p in storedProduct.GetType().GetProperties())
				{
					// check if it is NOT decorated with ReadOnly attribute
					if (!(p.GetCustomAttributes(typeof(ReadOnlyAttribute), false).Length > 0))
					{
						// i will use reflection to set the value
						p.SetValue(storedProduct,  p.GetValue(product, null), null);
					}
				}
			}
		}
		public Product Get(int id)
		{
			return _productsStore.Where(p => p.Id == id).FirstOrDefault();
		}
		public IEnumerable<Product> GetAll()
		{
			return _productsStore;
		}
	}
}
