    async Task UpdateUIAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            await Dispatcher.Yield(DispatcherPriority.Background);
            var data = await GetDataAsync();
            // do the UI-related work
            this.TextBlock.Text = "data " + data;
        }
    }
    async Task<int> GetDataAsync()
    {
        // simulate async data arrival
        await Task.Delay(10);
        return new Random(Environment.TickCount).Next(1, 100);
    }
    // start/stop
    CancellationTokenSource _cts;
    async void button_Click(object sender, RoutedEventArgs e)
    {
        if (_cts != null)
        {
            _cts.Cancel();
            _cts = null;
        }
        else
        {
            _cts = new CancellationTokenSource();
            try
            {
                await UpdateUIAsync(_cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
