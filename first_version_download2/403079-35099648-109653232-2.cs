    private void backworker_PING_DoWork(object sender, DoWorkEventArgs e)
    {
        bool pingable = false;
        Ping pinger = new Ping();
        try
        {
            PingReply reply = pinger.Send(MainWindow.GlobalVar.global_ip);
            if (reply.Status == IPStatus.Success)
            {
                pingable = true;
            }
            else
            {
                pingable = false;
            }
        }
        catch (PingException)
        {
            // Discard PingExceptions and return false;
        }
        //System.Windows.Forms.MessageBox.Show("...");
        if (pingable == true)
        {
            Dispatcher.Invoke(() => this.pingtxt.Content = MainWindow.GlobalVar.global_ip + " is Ping able.");
        }
        else
        {
            Dispatcher.Invoke(
                () => this.pingtxt.Content = @"[!]" + MainWindow.GlobalVar.global_ip + " is unPingable.");
        }
    }
