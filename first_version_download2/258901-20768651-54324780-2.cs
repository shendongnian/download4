    // helper functions
    public void DoEvents()
    {
        DispatcherFrame frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
            new DispatcherOperationCallback(ExitFrame), frame);
        Dispatcher.PushFrame(frame);
    }
    public object ExitFrame(object f)
    {
        ((DispatcherFrame)f).Continue = false;
        return null;
    }
    // in your code:  
    while(!_dialogClosed.WaitOne(200)) 
        DoEvents();
   
