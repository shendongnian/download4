    static void FixTheCrazy(DbCommand command) {
        foreach(DbParameter param in command.Parameters) {
            if(param.Value == null) param.Value = DBNull.Value;
        }
    }
