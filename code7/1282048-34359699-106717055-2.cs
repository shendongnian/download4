    public class Context : DbContext
    {
        public DbSet<Fluxo> Fluxo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    public class FluxoPrincipalMap : EntityTypeConfiguration<FluxoPrincipal>
    {
        public FluxoPrincipalMap()
        {
            HasKey(x => x.FluxoID);
        }
    }
    public class FluxoAlternativoMap : EntityTypeConfiguration<FluxoAlternativo>
    {
        public FluxoAlternativoMap()
        {
            HasKey(x => x.FluxoID);
        }
    }
    class FluxoDeExcecaoMap : EntityTypeConfiguration<FluxoDeExcecao>
    {
        public FluxoDeExcecaoMap()
        {
            HasKey(x => x.FluxoID);
        }
    }
