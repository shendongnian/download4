     var   customerEntity = new CrmEDMContainer(ConnectionStringCustomerDB());
                        var connection = new SqlConnection();
                        connection =(SqlConnection) customerEntity.Database.Connection;
                        connection.Open();
                        var command = new SqlCommand();                
                        string federationCmdText = @"USE FEDERATION Customer_Federation(ShardId =" + shardId + ") WITH RESET, FILTERING=ON";
                        command.Connection = connection;
                        command.CommandText = federationCmdText;
                        command.ExecuteNonQuery();
    return customerEntity ;
