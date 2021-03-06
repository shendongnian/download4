        public List<ConnectionString> GetConnection()
        {
            List<ConnectionString> conStr = new List<ConnectionString>();
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                if (!(css.Name == "LocalSqlServer" || css.Name == "LocalMySqlServer"))
                {
                    ConnectionString conn = new ConnectionString();
                    conn.name = css.Name;
                    conn.conString = css.ConnectionString;
                    conn.provider = css.ProviderName;
                    conStr.Add(conn);
                }
            }
            return conStr;
        }
