    private void btnGo_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            int intCount = 20;    
            while (intCount >= 20 && intCount <30)
            {
                intCount = intCount + 1;
                Invoke(new MethodInvoker(() => txtblkCount.Text = intCount.ToString()));
                System.Threading.Thread.Sleep(1000);
            }
        });
    }
