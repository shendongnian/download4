    class DataItem 
    {
       public string id { get; set; }
       public string name { get; set; }
       public string age { get; set; }
    }
    
    //Select statement
    public List<DataITem> Select()
    {
        string query = "SELECT * FROM tableinfo";
    
        //Create a list to store the result
        List<DataItem> list = new List<DateItem>();
    
        //Open connection
        if (this.OpenConnection())
        {
            //Create Command
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
               //Create a data reader and Execute the command
               using (MySqlDataReader dataReader = cmd.ExecuteReader())
               {
            
                  //Read the data and store them in the list
                  while (dataReader.Read())
                  {
                     list.Add(new DataItem() { id = dataReader["id"] + "",
                                               name = dataReader["name"] + "",
                                               age = dataReader["age"] + "" });
                  }
               }
            }
            this.CloseConnection();
        }
        return list;
    }
