    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
            if (MessageBox.Show("Do you want to close this application?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
    }
