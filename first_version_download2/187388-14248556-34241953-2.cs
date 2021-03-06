    public void FillDropDownList(string Query, ComboBox DropDownName)
    {
        string SQL = "SELECT id, name FROM info ORDER BY name"
        // If you use a DataTable (or any object which implmenets IEnumerable)
        // you can bind the results of your query directly as the 
        // datasource for the ComboBox. 
        DataTable dt = new DataTable();
        // Where possible, use the using block for data access. The 
        // using block handles disposal of resources and connection 
        // cleanup for you:
        using (var cn = new SqlConnection(CONNECTION_STRING))
        {
            using(var cmd = new SqlCommand(SQL, cn))
            {
                cn.Open();
                try
                {
                    dt.Load(cmd.ExecuteReader());
                }
                catch (SqlException e)
                {
                    // Do some logging or something. 
                    MessageBox.Show("There was an error accessing your data. DETAIL: " + e.ToString());
                }
            }
        }
        DropDownName.DataSource = dt;
        DropDownName.ValueMember = dt["id"];
        DropDownName.DisplayMember = dt["name"];
    }
