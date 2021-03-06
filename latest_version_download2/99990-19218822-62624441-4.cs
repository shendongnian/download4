    using (var disposables = new DisposableList())
    {
        var file = disposables.Add(() => File.Create("test"));
        // ...
        var memory = disposables.Add(() => new MemoryStream());
        // ...
        var cts = disposables.Add(() => new CancellationTokenSource());
        // ... 
    }
