    private void button2_Click(object sender, EventArgs e)
    {
      
      for(int i = 0; i < listBox1.Items.Count; i++)
      {
          listBox3.Items.Add(listBox1.Items[i].ToString());
      }
    
      for(int j = 0; j < listBox2.Items.Count; j++)
      {
          listBox3.Items.Add(listBox2.Items[j].ToString());
      }
    
    }
