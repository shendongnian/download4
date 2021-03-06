    /// <summary>
    /// Invoked once a connection is accepted by StreamSocketListener.
    /// </summary>
    /// <param name="sender">The listener that accepted the connection.</param>
    /// <param name="args">Parameters associated with the accepted connection.</param>
    private async void OnConnection(
        StreamSocketListener sender, 
        StreamSocketListenerConnectionReceivedEventArgs args)
    {
        DataReader reader = new DataReader(args.Socket.InputStream);
        try
        {
            while (true)
            {
                // Read first 4 bytes (length of the subsequent string).
                uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
                if (sizeFieldCount != sizeof(uint))
                {
                    // The underlying socket was closed before we were able to read the whole data.
                    return;
                }
    
                // Read the string.
                uint stringLength = reader.ReadUInt32();
                uint actualStringLength = await reader.LoadAsync(stringLength);
                if (stringLength != actualStringLength)
                {
                    // The underlying socket was closed before we were able to read the whole data.
                    return;
                }
    
                // Display the string on the screen. The event is invoked on a non-UI thread, so we need to marshal
                // the text back to the UI thread.
                NotifyUserFromAsyncThread(
                    String.Format("Received data: \"{0}\"", reader.ReadString(actualStringLength)), 
                    NotifyType.StatusMessage);
            }
        }
        catch (Exception exception)
        {
            // If this is an unknown status it means that the error is fatal and retry will likely fail.
            if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
            {
                throw;
            }
    
            NotifyUserFromAsyncThread(
                "Read stream failed with error: " + exception.Message, 
                NotifyType.ErrorMessage);
        }
    }
