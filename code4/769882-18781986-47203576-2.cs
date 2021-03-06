     var mre = new ManualResetEvent(false);
     var bgWkr = new BackgroundWorker();
     bgWkr.DoWork += delegate(object sender, DoWorkEventArgs e)
     {
         using(var mrEvent = e.Argument as ManualResetEvent)
         {
             // some processing...
             mrEvent.WaitOne();
         }
         // broadcast an event
     };
     bgWkr.RunWorkerAsync(mre);
     // some other processing...
     // hook into the same event
     mre.Set();
