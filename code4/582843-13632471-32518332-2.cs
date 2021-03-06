    this.picBoxs[i].Click += new System.EventHandler(Boxes_Click);
    this.picBoxs[i].Name = string.Format("box{0:D2}", i);
    ...
    void Boxes_Click(object sender, EventArgs e)
    {
        PictureBox theBox = sender as PictureBox;
        if(theBox != null)
        {
             switch(theBox.Name)
             {
                 case "box01" : // do box specific stuff here;
                 case "box99" : // do box specific stuff here;
             }
    
             // or general stuff here:
             MessageBox.Show("Box was clicked, name: {0}", theBox.Name);
             theBox.Visible = false;
        } 
    } 
