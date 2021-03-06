    private Storyboard stb = new Storyboard();
    private TimeSpan tsp = new TimeSpan();
                
    public MainWindow()
    {
        InitializeComponent();
        stb.CurrentTimeInvalidated += new EventHandler(doSomething);            
    }
    
    private void doSomething(Object sender, EventArgs e)
    {
        Clock storyboardClock = (Clock)sender;
            // or whatever other logic you want
        if (storyboardClock.CurrentTime.Value.Seconds % 2 == 0 && 
           Math.Abs((storyboardClock.CurrentTime.Value - tsp).TotalSeconds) >= 2)
        {
            // or something like this...
            tsp = storyboardClock.CurrentTime.Value
             - new TimeSpan(0,0,0,0,storyboardClock.CurrentTime.Value.Milliseconds);
            // do something
        }
    }
