    // This line of code is generated by Data Source Configuration Wizard
    // Instantiate a new DBContext
    WindowsFormsApplication2.CountriesDBEntities dbContext = new WindowsFormsApplication2.CountriesDBEntities();
    // Call the Load method to get the data for the given DbSet from the database.
    dbContext.Countries.Load();
    // This line of code is generated by Data Source Configuration Wizard
    gridLookUpEdit1.Properties.DataSource = dbContext.Countries.Local.ToBindingList();
