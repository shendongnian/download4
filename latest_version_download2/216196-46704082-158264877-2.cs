    if (listBox1.SelectedIndex == -1 || listBox2.SelectedIndex == -1)
    {
        label1.Text = "Please select currencies";
    }
    else
    {
        LB1 = listBox1.SelectedItem.ToString();  //Doesn't always run
        LB2 = listBox2.SelectedItem.ToString();
        Conversion();
    }
    //Always runs
    pictureBox1.Image = Properties.Resources.ResourceManager.GetObject(LB1) as Image;
    pictureBox2.Image = Properties.Resources.ResourceManager.GetObject(LB2) as Image;
