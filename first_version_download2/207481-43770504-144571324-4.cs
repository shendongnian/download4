        // Opens an encrypted database   
        string connString = "Data Source=c:\\test.db3;Password=something";    
        SQLiteConnection conn = new SQLiteConnection(connString);
        conn.Open();    
        // Encrypts the database. The connection remains valid and usable afterwards until closed - then the connection string needs updating.    
        conn.ChangePassword("somethingelse");
        conn.Close();
        connString = "Data Source=c:\\test.db3;Password=somethingelse";    
