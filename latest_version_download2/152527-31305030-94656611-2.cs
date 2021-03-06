    private Timer processingTimer;
    
    public YourService()
    {
        InitializeComponent();
        //Initialize timer
        processingTimer = new Timer(60000); //Set to run every 60 seconds
        processingTimer.Elapsed += processingTimer_Elapsed;
        processingTimer.AutoReset = true;
        processingTimer.Enabled = true;
    }
    private void processingTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Check the time
        if (timeCheck && haventRunToday)
            //Run your code
            //You should probably still run this as a separate thread
            this.RunService();
    }
    protected override void OnStart(string[] args)
    {
        //Start the timer
        processingTimer.Start();
    }
    protected override void OnStop()
    {
        //Check to make sure that your code isn't still running... (if separate thread)
        
        //Stop the timer
        processingTimer.Stop();
    }
    protected override void OnPause()
    {
        //Stop the timer
        processingTimer.Stop();
    }
    protected override void OnContinue()
    {
        //Start the timer
        processingTimer.Start();
    }
