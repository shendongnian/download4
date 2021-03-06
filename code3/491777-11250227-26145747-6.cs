    // Create a pie chart
    Chart chart = new Chart();
    
    // Choose chart type and add series info
    Series series = new Series("Default");
    series.ChartType = SeriesChartType.Pie;
    chart.Series.Add(series);
    
    // Create chart legend
    Legend legend = new Legend();
    chart.Legends.Add(legend);
    
    // Define the chart area
    ChartArea chartArea = new ChartArea();
    ChartArea3DStyle areaStyle = new ChartArea3DStyle(chartArea);
    areaStyle.Rotation = 0;
    chart.ChartAreas.Add(chartArea);
    
    Axis yAxis = new Axis(chartArea, AxisName.Y);
    Axis xAxis = new Axis(chartArea, AxisName.X);
                                     
    // Bind the data to the chart
    chart.Series["Default"].Points.DataBindXY(xValues, yValues);
    
    // Save the chart as a 300 x 200 image
    chart.Width = new System.Web.UI.WebControls.Unit(300, System.Web.UI.WebControls.UnitType.Pixel);
    chart.Height = new System.Web.UI.WebControls.Unit(200, System.Web.UI.WebControls.UnitType.Pixel);
    string filename = Server.MapPath("~") + "/Chart.png";
    chart.SaveImage(filename, ChartImageFormat.Png);
