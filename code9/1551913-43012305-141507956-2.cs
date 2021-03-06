    var query = "SELECT ProcessId, Name, ExecutablePath FROM Win32_Process";
    using (var searcher = new ManagementObjectSearcher(query))
    using (var results = searcher.Get())
    {
        var processes = results.Cast<ManagementObject>().Select(x => new
        {
            ProcessId = (UInt32)x["ProcessId"],
            Name = (string)x["Name"],
            Path = (string)x["ExecutablePath"]
        });
        foreach (var p in processes)
        {
            if (System.IO.File.Exists(p.Path))
            {
                var icon = Icon.ExtractAssociatedIcon(p.Path);
                var key = p.ProcessId.ToString();
                this.imageList1.Images.Add(key, icon.ToBitmap());
                this.listView1.Items.Add(p.Name, key);
            }
        }
    }
