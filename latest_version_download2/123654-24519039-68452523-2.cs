    private void button1_Click(object sender, EventArgs e)
        {            
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
    
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                string strfilename = openFileDialog1.FileName;
                                string filetext = File.ReadAllText(strfilename);
                                textBox1.Text = filetext;
                                button1.PerformClick();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
