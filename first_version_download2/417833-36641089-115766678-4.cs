    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        Point mp = e.Location;
        Legend L = chart1.Legends[0];
        RectangleF LCR = LegendClientRectangle(chart1, L);
        int sCount = chart1.Series.Count;
        if ( LCR.Contains(mp) )
        {
            int yh = (int) (LCR.Height / sCount);
            int myRel = (int)(mp.Y - LCR.Y);
            int ser = myRel / yh;             // <--- this is the series index
            // decide which you have set and want to use..:
            Console.WriteLine("Series # " + ser + " ->  " + 
              chart1.Series[ser].LegendText + " / " + chart1.Series[ser].Name);
        }
    }
