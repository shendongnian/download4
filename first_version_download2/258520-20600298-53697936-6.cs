    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable temp = new DataTable();
        string text = comboBox1.SelectedItem.ToString();
        selectedColor = Color.Get(text);
        comboBox2.DataSource = temp;
        comboBox2.DisplayMember = "Color_Name";
        comboBox2.ValueMember = "Color_ID";
        comboBox2.SelectedItem = selectedColor;
    }
