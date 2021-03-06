    void Page_Load(Object sender, EventArgs e)
    {
    // This example uses Microsoft SQL Server and connects
    // to the Northwind sample database. The data source needs
    // to be bound to the GridView control only when the 
    // page is first loaded. Thereafter, the values are
    // stored in view state.                      
    if(!IsPostBack)
    {
      // Declare the query string.
      String queryString = 
        "Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]";
      // Run the query and bind the resulting DataSet
      // to the GridView control.
      DataSet ds = GetData(queryString);
      if (ds.Tables.Count > 0)
      {
        AuthorsGridView.DataSource = ds;
        AuthorsGridView.DataBind();
      }
      else
      {
        Message.Text = "Unable to connect to the database.";
      }
    }   
    }
