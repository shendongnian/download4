      protected void textBox1_Validating (object sender,
       System.ComponentModel.CancelEventArgs e)
    {
       try
       {
          int x = Int32.Parse(textBox1.Text);
          errorProvider1.SetError(textBox1, "");
       }
       catch (Exception ex)
       {
          errorProvider1.SetError(textBox1, "Not an integer value.");
       }
    }
