    public static MySqlConnection getConnection()
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(connect);
                connect.Open();
                return connect;
            }
            catch (MySqlException e)
            {
                throw new Exception("Cannot connect", e);
            }
        }
