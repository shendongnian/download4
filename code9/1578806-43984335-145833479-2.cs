    public class DbContextFactory<C> : IDbContext<C> where C: DbContext
    {
      ...
    }
    
    public C CreateContext() ...
