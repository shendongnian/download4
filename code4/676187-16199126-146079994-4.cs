    public ArrayList GetClothesByType(string ClothesType)
    {
        ArrayList list = new ArrayList();
    
        string query = "SELECT * FROM fusey WHERE type LIKE @ctype";
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        using(SqlConnection conn = new SqlConnection(connectionString))
        using(SqlCommand command = new SqlCommand(query, conn))
        { 
           command.Parameters.AddWithValue("@ctype", ClothesType);
           conn.Open();
           SqlDataReader reader = command.ExecuteReader();
           .....
        }
    }
