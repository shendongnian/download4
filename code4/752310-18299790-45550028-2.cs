    SqlCommand cmd = new SqlCommand(" DELETE from Records WHERE ([Student ID]='" + textBox1.Text + "')", con);
            MessageBox.Show("Data Deleted!", "Information ... ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    
            textBox1.Text = " "; 
    
            if (textBox1.Text == " ") 
            {
                MessageBox.Show("Please enter Student ID", "Delete Failed",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
            cmd.ExecuteNonQuery();
            con.Close();
