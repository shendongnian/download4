    private Timer timer1; 
    public void InitTimer()
    {
        timer1 = new Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 2000; // in miliseconds
        timer1.Start();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        isonline()
    }
