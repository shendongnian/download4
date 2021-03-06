    string connectionString = "datasource = localhost; port = 3306; username = root; password = Mypass;";
    using(MySqlConnection myConn = new MySqlConnection(connectionString))
    using(MySqlCommand selectCommand = new MySqlCommand())
    {
        selectCommand.CommandText = "SELECT COUNT(1) FROM dark_heresy.users WHERE users_=@User and password_=@Password";
        selectCommand.Connection = myConn;
        selectCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar).Value = TextUserName.Text);
        selectCommand.Parameters.Add(new MySqlParameter("Password", MySqlDbType.VarChar).Value = TextPassword.Text);
        myConn.Open();
        var ret = selectCommand.ExecuteScalar();
        var count = Convert.ToInt32(ret);
        if (count == 1)
        {
             MessageBox.Show("Connection Successful");
        }
        else if (count > 1)
        {
             MessageBox.Show("Duplication of Username and Password... Access Denied");
        }
        else
        {
              MessageBox.Show("Incorrect Username and/or Password");
        }  
    }
