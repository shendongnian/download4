    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
       if (e.CloseReason == CloseReason.UserClosing)
       {
          DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
          if (result != DialogResult.Yes)
          {
             e.Cancel = true;
          }
       }
       else
       {
          e.Cancel = true;
       }
    }	
