    System.Windows.Forms.SaveFileDialog dls = new System.Windows.Forms.SaveFileDialog();
    dls.CustomPlaces.Clear();
    dls.CustomPlaces.Add(AddGuidOfTheExternalDriveOneByOne);
    ....
    ....
    dls.ShowDialog();
