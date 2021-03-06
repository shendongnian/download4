    // GET: api/Person/XXX
    [HttpGet("{uname}", Name = "Get")]
    public Person Get(string uname)
    {
       // Don't do this. .Net uses connection pooling, where in most cases you really do want
       //   a new connection object for each call to the db
       //  ConnectMysql();
        string queryString = "SELECT * FROM users WHERE uname = @uname";
        using (var conn = new MySqlConnection("connection string here"))
        using (var cmd  = new MySqlCommand(queryString, conn))
        {
            cmd.Parameters.Add("@uname", MySqlDbType.VarChar, 20).Value = uname;
            conn.Open();
            using (var myReader As MySqlDataReader = cmd.ExecuteReader())
            {
                if (myReader.Read())
                {
                    return new Person() {
                        p.id = (int)myReader["id"],
                        p.name = myReader["uname"].ToString(),
                        p.password = myReader["pword"].ToString(),
                        p.email = myReader["email"].ToString()
                    };
                }
            }
        }
        return null;
    }
