    public void button1_Click(object sender, EventArgs e)
        {
            if (messageText.Text == "")
                messageText.Text = "a";
            else if(messageText.Text == "a")
            {
                messageText.Text = "b";
            }
            else if (messageText.Text == "b")
            {
                messageText.Text = "c";
            }
            else
            {
                messageText.Text = "";
            }
        }
    
 
 
  
