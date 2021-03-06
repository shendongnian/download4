    private void BindData(string productName, int quantity)
    {
        var dataTable = new DataTable();
        string sql = "SELECT prdctName, UnitPrice, @Quantity AS Quantity, " + 
                            "UnitPrice * @Quantity AS Total_Price " + 
                     "FROM ProductDetails " + 
                     "WHERE prdctName = @prdctName";
        using (var conn = new SqlConnection(connectionString))
        {
             using (var cmd = new SqlCommand(sql, conn))
             {
                 cmd.Parameters.AddWithValue("@prdctName", productName);
                 cmd.Parameters.AddWithValue("@Quantity", quantity);
                 using (var adapter = new SqlDataAdapter(cmd))
                 {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                 }
             }
        }
    }
