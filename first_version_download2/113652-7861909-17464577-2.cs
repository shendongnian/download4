    internal class TestDb : DbContext  
    {  
        public void SetSavingChanges(event evt)
                var oc = this as IObjectContextAdapter;
                oc.ObjectContext.SavingChanges -= evt;
                oc.ObjectContext.SavingChanges += evt;
        }
      
        public DbSet<Country> Countries { get; set; }  
    }  
