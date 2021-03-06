    CancellationTokenSource source = new CancellationTokenSource();
    source.CancelAfter(TimeSpan.FromSeconds(1));
    var tasks = urls.Select(url => Task.Run( async () => 
    {
        using (var webClient = new WebClient())
        {
            token.Register(webClient.CancelAsync);
            var result = (Url: url, Data: await webClient.DownloadStringTaskAsync(url));
            token.ThrowIfCancellationRequested();
            return result.Url;
        }
    }, token)).ToArray();
    string url;
    try
    {
        // (A canceled task will raise an exception when awaited).
        var firstTask = await Task.WhenAny(tasks);
        url = (await firstTask).Url;
    }   
    catch (AggregateException ae) {
       foreach (Exception e in ae.InnerExceptions) {
          if (e is TaskCanceledException)
             Console.WriteLine("Timeout: {0}", 
                               ((TaskCanceledException) e).Message);
          else
             Console.WriteLine("Exception: " + e.GetType().Name);
       }
    }
