    namespace MyNameSpace
    {
       public class MySqlConnection : IDbConnection
       {
          private readonly IDbConnection _sqlConnection;
    
          public MySqlConnection()
          {
              var sqlConnection = new SqlConnection;
              sqlConnection.AccessToken = "Hello World";
              _sqlConnection = sqlConnection;
          }
    
          public string ConnectionString
          {
              get => _sqlConnection.ConnectionString;
              set => _sqlConnection.ConnectionString = value;
          }
    
          public int ConnectionTimeout => _sqlConnection.ConnectionTimeout;
          public string Database => _sqlConnection.Database;
          public ConnectionState State => _sqlConnection.State;
          public IDbTransaction BeginTransaction() => _sqlConnection.BeginTransaction();
          public IDbTransaction BeginTransaction(IsolationLevel il) => _sqlConnection.BeginTransaction(il);
          public void ChangeDatabase(string databaseName) => _sqlConnection.ChangeDatabase(databaseName);
          public void Close() => _sqlConnection.Close();
          public IDbCommand CreateCommand() => _sqlConnection.CreateCommand();
          public void Open() => _sqlConnection.Open();
          public void Dispose() => _sqlConnection.Dispose();
       }
    }
