    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await Task.Run(() =>
            {
                var deviceManager = new DeviceManager();
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }
                    lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                }
            });
        }
        catch (COMException ex)
        {
            MessageBox.Show(ex.Message);
        }
    
        try
        {
            await Task.Run(() =>
            {
                var deviceManager = new DeviceManager();
    
                DeviceInfo AvailableScanner = null;
    
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }
    
                    AvailableScanner = deviceManager.DeviceInfos[i];
                    break;
                }
                var device = AvailableScanner.Connect();
                var ScanerItem = device.Items[1];
                var imgFile = (ImageFile)ScanerItem.Transfer();
                var data = (byte[])imgFile.FileData.get_BinaryData();
                var bitmap = GetBitmapFromRawData(imgFile.Width, imgFile.Height, data);
                var Path = @"C:\....\ScanImg.jpg";
                bitmap.Save(Path, ImageFormat.Jpeg);
            });
        }
        catch (COMException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
