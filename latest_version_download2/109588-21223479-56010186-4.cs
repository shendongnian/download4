    ...
    // use the webclient object to download the file
    using (System.Net.WebClient client = new System.Net.WebClient())
    {
        ...
        // pass the filename as the second argument (change 0 to the correct %)
        backgroundWorker1.ReportProgress(0, FileName);
        ...
