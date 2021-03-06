    protected void SomeButton_Click(Object sender, EventArgs e)
    {
        // Task off the work and do not wait, no blocking here.
        Task.Run(PerformConnection);
    }
    private async Task PerformConnection()
    {
        // This method acts the way a thread should.  We await the result of async comms.
        // This will not block the UI but also may or may not run on its own thread.
        // You don't need to care about the threading much.
        var conn = await ListenerOrSomething.AwaitConnectionsAsync( /* ... */ );
        // Now you have your result because it awaited.
        using(var newClient = conn.Client())
        {
            var buffer = new byte[];           
            var recv = await newClient.ReceiveAsyncOrSomething(out buffer);
 
            // Data received is not zero, process it or return
            if(recv > 0)
                newClient.Response = await ProcessRequest(buffer);
            else
                return;
        }
    }
