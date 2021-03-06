    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Frame rootFrame = Window.Current.Content as Frame;
    
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == null)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();
    
            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }
    
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }
    
        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
    
            if (ApplicationData.Current.LocalSettings.Values["LastPage"] != null)
            {
                Type t = Type.GetType((string)ApplicationData.Current.LocalSettings.Values["LastPage"]);
                if (!rootFrame.Navigate(t, args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
    
            else
            {
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
        }
        // Ensure the current window is active
        Window.Current.Activate();
    }
