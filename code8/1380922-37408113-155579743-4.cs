    public DataSet ExecuteSelectProcedure(string procedeureName, params SqlParamDefinition[] parameters)
    {
        var ds = new DataSet();
        using (var con = new SqlConnection(DatabaseConnectionString))
        {
                
            using (var cmd = new SqlCommand(procedeureName, DbConn.objConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for(int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    cmd.Parameters.Add(new SqlParameter(param.Name, param.DbType).Value = param.Value);
                }
                try
                {
                    con.Open();
                    var objDataAdapter = new SqlDataAdapter();
                    objDataAdapter.SelectCommand = cmd;
                    objDataAdapter.Fill(ds);
                    con.Close();
                }
                catch (Exception ex)
                {
                    //sql_log_err
                }
            }
        }
        return ds;
    }
