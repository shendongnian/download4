    if (this.folderImages.SelectedIndex > 0)
    {
        string imageName = this.folderImages.SelectedItem as string;
        int index = this.folderImages.SelectedIndex;
                
        this.folderImages.Items.RemoveAt(index);
        this.folderImages.Items.Insert(index - 1, imageName);
        this.folderImages.SelectedIndex = index - 1;
    }
