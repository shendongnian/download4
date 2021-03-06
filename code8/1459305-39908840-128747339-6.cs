    string sql = "insert into foo values (:boo, :bar, :baz)";
    OracleCommand cmd = new OracleCommand(sql, conn);
    cmd.Parameters.Add(new OracleParameter("boo", OracleDbType.Varchar2));
    cmd.Parameters.Add(new OracleParameter("bar", OracleDbType.Date));
    cmd.Parameters.Add(new OracleParameter("baz", OracleDbType.Varchar2));
    cmd.Parameters[0].Value = booArray;
    cmd.Parameters[1].Value = barArray;
    cmd.Parameters[2].Value = bazArray;
    cmd.ArrayBindCount = booArray.Length;
    cmd.ExecuteNonQuery();
