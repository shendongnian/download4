    private void button1_click(object sender, EventArgs e)
    {
        //Do first stuffs
        button2_click(sender, e);
        
        if (!(sender as Button).Tag)
            return;
        //Do second stuffs
    }
    private void button2_click(object sender, EventArgs e)
    {
        //Do somthing
        Button button = sender as Button;
        button.Tag = true;
        if (myCondition)
        {
            button.Tag = false;
            return;
        }//Also return in button1_click
        //Do somthing else
    }
