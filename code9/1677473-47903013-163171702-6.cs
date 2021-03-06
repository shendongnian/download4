     System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    //ScatterMode Tab
    private void Scatter_modeToolStripMenuItem_Click(object sender, EventArgs e)
    {
            timer.Interval = 4000; //can go in the constructor also; don't need to set repeatedly
            timer.Enabled = true;
            timer.Tick += new EventHandler(Dosomething); //move to constructor
            timer.Start(); //this isn't needed - you already Enabled the timer, which started it
    }
    private void Dosomething (object sender, EventArgs e)
    {
        timer.Stop();          //use this
        timer.Enabled = false; //or this. It's not required to do both
        Grab.buffer(out buffer, out status, 6000);  //if these lines crash then your timer will
        Scatter_mode(buffer);                       //only restart if the toolstripmenuitemclick
        pictureBox1.Refresh();                      //above runs.. is it what you wanted?
        int done_grab = 1; //not needed
        if (doneGrab == 1) //this will always evaluate to true, it is not needed
        {
            timer.Interval = 4000; //the interval is already 4000, not needed
            timer.Enabled = true; //careful; your timer may stop forever if the code above crashes
            timer.Tick += new EventHandler(Scatter_modeToolStripMenuItem_Click); //remove
            timer.Start(); //not needed
            done_grab = 0; //not needed
        }
    }
