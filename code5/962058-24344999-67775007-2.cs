    ThreadPool.QueueUserWorkItem((state) =>
        {
                double x1_min = Convert.ToDouble(txt_x1_min.Text);
                double x1_max = Convert.ToDouble(txt_x1_max.Text);
                double x2_min = Convert.ToDouble(txt_x2_min.Text);
                double x2_max = Convert.ToDouble(txt_x2_max.Text);
                int iter = Convert.ToInt16(txtIterations.Text);
                //Data Defining and Computing
                obj.Run(x1_min, x1_max, x2_min, x2_max, iter);
    
       
    
            var data = PSOLib.table.DefaultView;
            Dispatcher.Invoke(new Action(() =>
            {
                myDataGrid.ItemsSource = data;
                Minima.Text = string.Format("{0,0:0.000} ", PSOLib.min);
            }));
        });
