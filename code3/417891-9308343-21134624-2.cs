    VideoCaptureDevice Cam1;
    FilterInfoCollection VideoCaptureDevices;
    
    VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
    Cam1 = new VideoCaptureDevice(VideoCaptureDevices[0].MonikerString);
    Cam1.DisplayPropertyPage(IntPtr.Zero); //This will display a form with camera controls
