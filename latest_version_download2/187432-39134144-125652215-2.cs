    private void button6_Click(object sender, EventArgs e)
    {
        GetNumber gtn = new GetNumber();
        gtn.Show();
        System.Timers.Timer timer = new Timer(6000);
        timer.Elapsed += (_, _2) => { Invoke((MethodInvoker)delegate { gtn.Close(); }); };
        timer.Start();
    }
