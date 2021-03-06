    private void button3_Click(object sender, EventArgs e)
    { 
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            textEditor.Text = "";
            using (BinaryReader br = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
	        {
    	        int pos = 0;
    	        int length = (int)br.BaseStream.Length;
                int numBytesToRead = 1;
                int numHexCharsPerLine = 5;
                int numCharsRead = 0;
	            while (pos < length)
	            {
                    byte[] buffer = br.ReadBytes(numBytesToRead);
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        textEditor.Text += buffer[i].ToString("X2");
                        textEditor.Text += " "; // Will put a space between each hex character
                        if (numCharsRead % numHexCharsPerLine == 0 && numCharsRead > 0)
                        {
                            textEditor.Text += "\r\n";
                        }
                        numCharsRead++;
                    }
                    pos += numBytesToRead;
	            }
	        }
        }
    }
