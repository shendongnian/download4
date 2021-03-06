    using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ahmed\OneDrive\Documents\shop.accdb"))
    {
        conn.Open();
        // DbCommand also implements IDisposable
        using (OleDbCommand cmd = conn.CreateCommand())
        {
            var param1 = new OleDbParameter("@DateTimePicker1", OleDbType.DBDate); //you may have to play with different types
            param1.Value = dateTimePicker1.Value;
            cmd.Parameters.Add(param1);
            var param2 = new OleDbParameter("@DateTimePicker2", OleDbType.DBDate);
            param2.Value = dateTimePicker2.Value;
            cmd.Parameters.Add(param2);
            cmd.CommandText = "SELECT * from tbl3 Where datetime >= @DateTimePicker1 and datetime <= @DateTimePicker2";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = new BindingSource(dt, null);
        }
    }
