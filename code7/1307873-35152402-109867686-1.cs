    chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].RecalculateAxesScale();
            series1.Name = "Series1";
            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerColor = Color.BlueViolet;
            series1.MarkerSize = 10;
            series1.Color = System.Drawing.Color.Green;
            //series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            //series1.XValueType = ChartValueType.Time;
            series1.YAxisType = AxisType.Primary;
            series1.ChartType = SeriesChartType.Line;
            this.chart1.Series.Add(series1);
