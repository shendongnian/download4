    string img = null;
    
    private void btnShow_Click(object sender, EventArgs e)
    {
        string imgName;
        img = textBox1.Text;
        imgName = "images/" + img + ".jpg";
        
        if (imgName == null)
        {
            MessageBox.Show("no photo");
        }
        else if (imgName != null)
        {
            this.picBox1.Image = Image.FromFile("images/" + img + ".jpg");
        }
    }
