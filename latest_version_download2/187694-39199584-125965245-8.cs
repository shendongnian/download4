    private void button1_Click(object sender, EventArgs e)
    {
        string str = textBox1.Text;
        Image img = Image.FromFile(str);
        pictureBox1.Image = img;
    }
