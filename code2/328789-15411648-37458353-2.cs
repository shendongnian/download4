    void File_Changed(object sender, FileSystemEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);
            string extension = f.Extension;
            // filter file types 
            if (f.Extension.Equals(".jpg") || f.Extension.Equals(".png"))
            {
               //Logic to do whatever it is you're trying to do goes here               
            }
    }
    
