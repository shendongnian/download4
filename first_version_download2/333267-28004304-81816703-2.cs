    private void WatermarkPicker_Load(object sender, EventArgs e)
    {
        listView1.View = View.LargeIcon;
        listView1.LargeImageList = imageList1;
        
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do not try to use in any way an object derived from Control
        // like the ListView.....
        BackgroundWorker worker = sender as BackgroundWorker;
        DirectoryInfo dir = new DirectoryInfo(@"c:\pics");
        foreach (FileInfo file in dir.GetFiles())
        {
            // Raise the ProgressChanged event. The code there will
            // execute in the UI Thread
            worker.ReportProgress(1, file);        
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender,  ProgressChangedEventArgs e)
    {
        try
        {
            FileInfo file = e.UserState as FileInfo;
            Console.WriteLine(file.FullName);
            iLst.Images.Add(file.Name, Image.FromFile(file.FullName));
            ListViewItem item = new ListViewItem(file.Name);
            item.Tag = file.Name;
            item.ImageIndex = imageList1.Images.Count - 1;
            listView1.Items.Add(item);
         }
         catch(Exception ex)
         {
            ....
         }
    }
