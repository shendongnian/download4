    var list = new List<string>();
    while(MySqlDataReader.Read())
    {
       string name = MySqlDataReader["FatherFullName"].ToString();
       if(!string.IsNullOrEmpty(name))
       {
          list.Add(name);
       }
    }
    Response.Write(string.Join(",", list)); // 1,2,3,4
