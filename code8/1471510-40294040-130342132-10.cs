    public class Parent
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
    public class Child
    {
        public int ChildId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
    public class ParentConfiguration : EntityTypeConfiguration<Parent>
    {
        public ParentConfiguration()
        {
            HasKey(x => x.ParentId);
        }
    }
    public class ChildConfiguration : EntityTypeConfiguration<Child>
    {
        public ChildConfiguration()
        {
            HasKey(x => x.ChildId);
        }
    }
    public class TesteContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Childs { get; set; }
        public TesteContext() : base("Teste_123")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ParentConfiguration());
            modelBuilder.Configurations.Add(new ChildConfiguration());
        }
    }
