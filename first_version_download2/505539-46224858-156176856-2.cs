    protected void AddEvent(object sender, EventArgs e)
    {
        //Cast to LinkButton
        var linkButton = (LinkButton)sender;
        //Or use is keyword like below
        if (sender is LinkButton)
        {
                
        }
    }
