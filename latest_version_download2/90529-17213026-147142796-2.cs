	private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
	{
		if (Directory.Exists(e.FullPath)) // Is it a folder?
		{
			// Do whatever you want to do with a folder instead of a file.
            // You'll need to check if target is right: It needs to be the name of an exisitng folder.
            CopyDirectories(e.FullPath, target);
		}
		else
		{
			if (WaitForFileAvailable(e.FullPath, TimeSpan.FromSeconds(10)))
			{
				listBox1.Items.Add("File created> " + e.FullPath + " -Date:" + DateTime.Now);
				File.Copy(e.FullPath, Path.Combine(target, e.Name));
			}
			else // The file failed to become available within 10 seconds.
			{
				// Error handling.
			}
		}
	}
			
