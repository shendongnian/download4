    private void ContentTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Control && e.KeyCode == Keys.A)
        {
            MessageBox.Show("Ctrl + a detected");
        }
    }
