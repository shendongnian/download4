    string sql = "Select Name,Father_name,NIC_No,Image from Admform WHERE Member_ID=@memid";.
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        var memidParam = new SqlParameter("memid", SqlDbType.Int);
        memidParam.Value = textBoxmember.Text;
    
        command.Parameters.Add(memidParam);
        var results = command.ExecuteReader();
		reader.Read();
        if (reader.HasRows)
        {
            textBoxname.Text = reader[0].ToString();
            textBoxfname.Text = reader[1].ToString();
            textBoxnic.Text = reader[2].ToString();
            byte[] img = (byte[])(reader[3]);
            if (img == null)
                pictureBox1.Image = null;
            else
            {
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }
        else
        {
            MessageBox.Show("This is does not exist.");
        }
    }
