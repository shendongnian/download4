    public class SomeContext : DbContext
    {
        public SomeContext() : base("name=DefaultConnection")
        {
        }
    
        public static SomeContext Create()
        {
            return new SomeContext();
        }
    
        public DbSet<User> Users { get; set; }
    
    }
