    private void button1_Click(object sender, EventArgs e)
    {
       RandomNumber(0,99);
       button2.Enabled = true ;
       button1.Enabled = false;
       label3.Visible = true;
       
       if (textBox1.Text == label1.Text)
       {
         label3.Text=("Winner");
         label6.Text = (++this.Correct).ToString();
       }
       else
       {  
          label3.Text=(string.Format("Sorry - You Lose, The number is {0}", label1.Text));
          label7.Text = (++this.Incorrect).ToString();
       } 
    }
