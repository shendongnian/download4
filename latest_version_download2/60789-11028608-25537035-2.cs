    // Create a new SqlConnectionStringBuilder and
        // initialize it with a few name/value pairs.
        SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(GetConnectionString());
        // The input connection string used the 
        // Server key, but the new connection string uses
        // the well-known Data Source key instead.
        Console.WriteLine(builder.ConnectionString);
        // Pass the SqlConnectionStringBuilder an existing 
        // connection string, and you can retrieve and
        // modify any of the elements.
        builder.ConnectionString = "server=(local);user id=ab;" +
            "password= a!Pass113;initial catalog=AdventureWorks";
        // Now that the connection string has been parsed,
        // you can work with individual items.
        Console.WriteLine(builder.Password);
        builder.Password = "new@1Password";
        builder.AsynchronousProcessing = true;
        // You can refer to connection keys using strings, 
        // as well. When you use this technique (the default
        // Item property in Visual Basic, or the indexer in C#),
        // you can specify any synonym for the connection string key
        // name.
        builder["Server"] = ".";
        builder["Connect Timeout"] = 1000;
        builder["Trusted_Connection"] = true;
        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
