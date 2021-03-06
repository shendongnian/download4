    private void DataGridBinding_Load(object sender, System.EventArgs e)
    {
       // Populate series data using random data
      double[]    yValues = { 23.67, 75.45, 60.45, 34.54, 85.62, 32.43, 55.98, 67.23 };
      for(int pointIndex = 0; pointIndex < yValues.Length; pointIndex++)
      {
        chart1.Series["Series1"].Points.AddXY(1990 + pointIndex, yValues[pointIndex]);
      }
        
      // Export series values into DataSet object
      dataSet1 = chart1.DataManipulator.ExportSeriesValues("Series1");
      // Data bind DataGrid control. 
      SeriesValuesDataGrid.DataSource = dataSet1;
      // Set Series name for data
      SeriesValuesDataGrid.DataMember = "Series1";
    }
    private void SeriesValuesDataGrid_CurrentCellChanged(object sender,System.EventArgs e)
    {
       // Initializes a new instance of the DataView class
       DataView firstView = new DataView(dataSet1.Tables[0]);
       // Since the DataView implements IEnumerable, pass the reader directly into
       // the DataBind method with the name of the Columns selected in the query    
       chart1.Series["Series1"].Points.DataBindXY(firstView,"X",firstView,"Y");
       // Invalidate Chart
       chart1.Invalidate();
    }
