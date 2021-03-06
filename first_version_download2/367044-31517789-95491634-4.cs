    public MigratorContext(string connString)
       : base( connString)
    {
        var migrationConfiguration = new MigrationConf();
    
    	Database.SetInitializer<MigratorContext>(
    		new MigrateDatabaseToLatestVersion<
    			MigratorContext<T>, MigratorContext<T>.MigrationConf>(true, migrationConfiguration));
    }
    
    public sealed class MigrationConf : DbMigrationsConfiguration<MigratorContext>
    {
    	public MigrationConf()
    		: base()
    	{
    		AutomaticMigrationsEnabled = true;
    		AutomaticMigrationDataLossAllowed = true;
    	}
    }
