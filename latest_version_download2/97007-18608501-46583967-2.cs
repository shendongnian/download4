    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
       DataRowView drv = (DataRowView)dataGridView1.SelectedItem;
       int id = drv.Row[0];
       if(drv != null)
       {
           delete(id);
       }
    }
    public void delete(int id)
    { 
       try 
       {
          con.Open();
          OleDbCommand comm = new OleDbCommand("delete from Member where id=@id", con);
          comm.Parameters.AddWithValue("@id", id);
          comm.ExecuteNonQuery();
       }
       catch(OleDbException ex)
       {
           MessageBox.Show("DataConnection not found!", ex);
       }
       finally
       {
           con.Close();
       }
