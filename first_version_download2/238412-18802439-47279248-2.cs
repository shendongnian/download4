    btn1.Click += MainEvent;
    btn2.Click += MainEvent;
    btn3.Click += MainEvent;
    protected void MainEvent(object sender, EventArgs e)
    {
        string example;
        if(sender is btn1)
        {
            example = a
        }
        else if(sender is btn2)
        {
            example = b
        }
        else if(sender is btn3)
        {
            example = c
        }
    
        //Do whatever with example
    }
