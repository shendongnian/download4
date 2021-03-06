    OracleParameter[] queryParams = new OracleParameter[6];
    queryParams[0] = new OracleParameter("START_DATE", OracleDbType.Date, 2, strStartDate, System.Data.ParameterDirection.Input);
    queryParams[1] = new OracleParameter("END_DATE", OracleDbType.Date, 4, strEndDate, System.Data.ParameterDirection.Input);
    queryParams[2] = new OracleParameter("START_TIME", OracleDbType.TimeStampLTZ, 2, strStartTime, System.Data.ParameterDirection.Input);
    queryParams[3] = new OracleParameter("END_TIME", OracleDbType.TimeStampLTZ, 2, strEndTime, System.Data.ParameterDirection.Input);
    queryParams[4] = new OracleParameter("PROG_NAME", OracleDbType.Varchar2, 50, strProgName, System.Data.ParameterDirection.Input);
    queryParams[5] = new OracleParameter("CHANNEL_ID", OracleDbType.Int32, 50, strChannelID, System.Data.ParameterDirection.Input);
