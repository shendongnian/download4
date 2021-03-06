    using System.Windows.Forms.DataVisualization.Charting;
    ...
    private Thread addDataRunner;
    private Random rand = new Random();
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    public delegate void AddDataDelegate();
    public AddDataDelegate addDataDel;
    ...
    
    private void RealTimeSample_Load(object sender, System.EventArgs e)
    {
    
        // create the Adding Data Thread but do not start until start button clicked
        ThreadStart addDataThreadStart = new ThreadStart(AddDataThreadLoop);
        addDataRunner = new Thread(addDataThreadStart);
    
        // create a delegate for adding data
        addDataDel += new AddDataDelegate(AddData);
    
    }
    
    private void startTrending_Click(object sender, System.EventArgs e)
    {
        // Disable all controls on the form
        startTrending.Enabled = false;
        // and only Enable the Stop button
        stopTrending.Enabled = true;
    
        // Predefine the viewing area of the chart
        minValue = DateTime.Now;
        maxValue = minValue.AddSeconds(120);
    
        chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
        chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
    
        // Reset number of series in the chart.
        chart1.Series.Clear();
    
        // create a line chart series
        Series newSeries = new Series( "Series1" );
        newSeries.ChartType = SeriesChartType.Line;
        newSeries.BorderWidth = 2;
        newSeries.Color = Color.OrangeRed;
        newSeries.XValueType = ChartValueType.DateTime;
        chart1.Series.Add( newSeries );    
    
        // start worker threads.
        if ( addDataRunner.IsAlive == true )
        {
            addDataRunner.Resume();
        }
        else
        {
            addDataRunner.Start();
        }
    
    }
    
    private void stopTrending_Click(object sender, System.EventArgs e)
    {
        if ( addDataRunner.IsAlive == true )
        {
            addDataRunner.Suspend();
        }
    
        // Enable all controls on the form
        startTrending.Enabled = true;
        // and only Disable the Stop button
        stopTrending.Enabled = false;
    }
    
    /// Main loop for the thread that adds data to the chart.
    /// The main purpose of this function is to Invoke AddData
    /// function every 1000ms (1 second).
    private void AddDataThreadLoop()
    {
        while (true)
        {
            chart1.Invoke(addDataDel);
    
            Thread.Sleep(1000);
        }
    }
    
    public void AddData()
    {
        DateTime timeStamp = DateTime.Now;
    
        foreach ( Series ptSeries in chart1.Series )
        {
            AddNewPoint( timeStamp, ptSeries );
        }
    }
    
    /// The AddNewPoint function is called for each series in the chart when
    /// new points need to be added.  The new point will be placed at specified
    /// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
    /// data point's Y value, and not smaller than zero.
    public void AddNewPoint( DateTime timeStamp, System.Windows.Forms.DataVisualization.Charting.Series ptSeries )
    {
        double newVal = 0;
    
        if ( ptSeries.Points.Count > 0 )
        {
            newVal = ptSeries.Points[ptSeries.Points.Count -1 ].YValues[0] + (( rand.NextDouble() * 2 ) - 1 );
        }
    
        if ( newVal < 0 )
            newVal = 0;
    
        // Add new data point to its series.
        ptSeries.Points.AddXY( timeStamp.ToOADate(), rand.Next(10, 20));
    
        // remove all points from the source series older than 1.5 minutes.
        double removeBefore = timeStamp.AddSeconds( (double)(90) * ( -1 )).ToOADate();
        //remove oldest values to maintain a constant number of data points
        while ( ptSeries.Points[0].XValue < removeBefore )
        {
            ptSeries.Points.RemoveAt(0);
        }
    
        chart1.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
        chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddMinutes(2).ToOADate();
    
        chart1.Invalidate();
    }
    
    /// Clean up any resources being used.
    protected override void Dispose( bool disposing )
    {
        if ( (addDataRunner.ThreadState & ThreadState.Suspended) == ThreadState.Suspended)
        {
            addDataRunner.Resume();
        }
        addDataRunner.Abort();
    
        if( disposing )
        {
            if (components != null) 
            {
                components.Dispose();
            }
        }
        base.Dispose( disposing );
    }        
    ... 
