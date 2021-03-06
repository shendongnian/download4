    protected override void OnCreate(Bundle bundle)
    {
       base.OnCreate(bundle);
       // Set view
       SetContentView(Resource.Layout.Main);
       //create database if it doesn't exist
       DBRepository dbr = new DBRepository();
       dbr.CreateDatabase();
       //create table (if it doesn't exist)
       dbr.CreateTable();
       var items = dbr.GetData();
       var listView = FindViewById<ListView>(Android.Resource.Id.ListView);
       listView.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
    }
