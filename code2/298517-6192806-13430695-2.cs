	public event EventHandler StatusUpdated;
	private void FunctionThatRaisesEvent()
	{
        //Null check makes sure the main page is attached to the event
        if (this.StatusUpdated != null)
           this.StatusUpdated(new object(), new EventArgs());
	}
