    public abstract class BaseClass
    {
      public abstract void myFunc(SqlConnection conn);
      
      public void BaseFunc()
      {      
            using (SqlConnection conn = new SqlConnection(this.MyConnectionString))
            {
                conn.Open();
                myFunc(conn);
                ..any other base implementation...
            }
      }
    }
