    void Insert()
    {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customerOrder values(@Fname,@Lname)";
            cmd.Parameters.Add("@Fname",SqlDbType.NVarchar).Value = txtFname.Text;
            cmd.Parameters.Add("@Lname",SqlDbType.NVarchar).Value = txtLname.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            txtFname.Text = "";
            txtLname.Text = "";
            MessageBox.Show("Inserted Successfully!");    
     }
    
    void View()
     {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customerOrder";
            cmd.ExecuteNonQuery();
    
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
