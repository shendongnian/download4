    private dynamic Method()
        {
            .....
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query1, sqlConnection);
                sqlConnection.Open();
                adapter.Fill(dt);
            }
            var list = dt.AsEnumerable().ToList();
            return list;
        }
