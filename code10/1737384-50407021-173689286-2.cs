    BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
    public void UpdateProgressBar(int numberTableProcessed)
    {
      if (this.IsHandleCreated)
      {
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate{UpdateProgressBar(numberTableProcessed);});
            return;
        }
        else
        {
            int numberTotalTables = 22;
            progressBar1.Value = (numberTableProcessed * 100) / numberTotalTables
        }
    }
    
    this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    
