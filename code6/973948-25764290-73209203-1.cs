    I think you can handle the OnActivated event even in the page where you required. Something like this
    
     CoreApplicationView view = CoreApplication.GetCurrentView();
    
    ImagePath=string.Empty;
                FileOpenPicker filePicker = new FileOpenPicker();
                filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                filePicker.ViewMode = PickerViewMode.Thumbnail;
    
                // Filter to include a sample subset of file types
                filePicker.FileTypeFilter.Clear();
                filePicker.FileTypeFilter.Add(".bmp");
                filePicker.FileTypeFilter.Add(".png");
                filePicker.FileTypeFilter.Add(".jpeg");
                filePicker.FileTypeFilter.Add(".jpg");
    
    filePicker.PickSingleFileAndContinue();
                view.Activated += viewActivated; 
    
    private void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
            {
                FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
    
                if (args != null)
                {
                    if (args.Files.Count == 0) return;
    
                    view.Activated -= viewActivated;
                    storageFileWP = args.Files[0];
    
                }
            }
    
    When you select the files from the picker the above method will be called. I believe it helps you.
