    private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);
                toolStripStatusLabel5.Text = "Line" + " " + line.ToString();
                toolStripStatusLabel6.Text = " Column" + " " + line.ToString();
                toolStripStatusLabel3.Text = Cursor.Position.ToString(); // where is my mouse cursor at this Time like that x and y cordinate 330,334
                Update();
                
            }
        }
