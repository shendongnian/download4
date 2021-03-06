    protected void BtnSubmit_Click(object sender, EventArgs e) 
    {
     string connString = "sql database";
     string insertCommand = "INSERT INTO tbDrinks ( DrinkName, DateOfOrder, Qty, UserName, UserCompany) " +
      "values(@DrinkName, @DateOfOrder, @Qty, @UserName, @UserCompany)"; //for testing purpose
     using(SqlConnection conn = new SqlConnection(connString)) 
     {
      conn.Open();
      using(SqlCommand sqlcmd = new SqlCommand(insertCommand, conn)) {
       sqlcmd.Parameters.AddWithValue("@DrinkName", lblCoffee.Text);
       // sqlcmd.Parameters.AddWithValue("@DrinkName", lblEnglishTea.Text);
       sqlcmd.Parameters.AddWithValue("@DateOfOrder", DateTime.Today);
       sqlcmd.Parameters.AddWithValue("@Qty", ddlCoffee.SelectedValue);
       // sqlcmd.Parameters.AddWithValue("@Qty", ddlEnglishTea.SelectedValue);
       sqlcmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
       sqlcmd.Parameters.AddWithValue("@UserCompany", txtCompanyName.Text);
       sqlcmd.ExecuteNonQuery();
      }
     }
    }
