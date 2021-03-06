    public List<CustomerDto> Fetch()
    {
        using(var ctx = DbContextManager<CustomerContext>.GetManager("CustomerDB"))
        {
            var result = (from r in ctx.DbContext.Customers 
                         select new CustomerDto()
                         {
                             CustomerId = r.CustomerId,
                             Name = r.Name,
                             Email = r.Email
                         }).ToList();
            return result.ToList();
        }
    }
