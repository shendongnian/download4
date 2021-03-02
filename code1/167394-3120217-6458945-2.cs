    void watcher_Changed(object sender, FileSystemEventArgs e)
    {
        String text = File.ReadAllText(e.FullPath);
        this.Dispatcher.Invoke(DispatcherPriority.Normal, () => 
            {
                 this.txtFile.Text = text;
                 // Do all UI related work here...
            });
    }
