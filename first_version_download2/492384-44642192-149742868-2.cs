    static public volatile int WaitInterval = 200;
    public void StartLoop()
    {
    	Task.Factory.StartNew(async () =>
    	{
    		while (true)
    		{
    			App.Current.Dispatcher.Invoke(new Action(() =>
    			{
    					//Some number generated and set to a property
    				}));
    			await Task.Delay(WaitInterval);
    		}
    	});
    }
    
    protected mySlider_ValueChanged(object sender, SliderEventArgs e)
    {
    	WaitInterval = mySlider.Value;
    }
