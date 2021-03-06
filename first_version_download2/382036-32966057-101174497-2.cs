    // a class level reference, prepare it where you want..
    ContextMenuStrip ms = new ContextMenuStrip();
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        // disassociate from listview at first:
        listView1.ContextMenuStrip = null;
        // check for right button
        if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
        // get item info:
        ListViewHitTestInfo hi = listView1.HitTest(e.Location);
        // no item hit:
        if (hi.Item == null) return;
        // calculate the image rectangle:
        Rectangle r = new Rectangle(hi.Item.Position, imageList1.ImageSize);
       
        // no image hit:
        if ( !r.Contains(e.Location) ) return;
        // maybe prepare or change the menue now..
        ...
        ms.Location = e.Location;
        // associate with listview and show
        listView1.ContextMenuStrip = ms;
        ms.Show();
        // you can access the image name via the `Keys` array:
        Console.WriteLine("You have hit: " + imageList1.Images.Keys[hi.Item.ImageIndex] );
    }
