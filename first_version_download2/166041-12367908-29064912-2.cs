    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                richTextBox1.SelectionBackColor = Color.LightCoral;
            }
            else
            {
                richTextBox1.SelectionBackColor = Color.White;
            }
        }
