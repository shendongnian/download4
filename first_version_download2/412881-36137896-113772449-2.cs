    for (; ; i++)
    {
        tbOpenFile.Text = r_Read.ReadLine();
        lines[i] = tbOpenFile.Text;
    
        lb1.Items.Add(lines[i]);
        if (r_Read.EndOfStream.Equals(true))
        {
            break; // exits the loop.
        }
    }
    textBox2.Text = r_Read.EndOfStream.ToString();
    ReadStream.Close();
