    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if(textbox1.InvokeRequired)
        {
            textbox1.Invoke(new SerialDataReceivedEventHandler(sp_DataReceived), sender, e);
        }
        else
        {
            var valueOfPort = sp1.ReadExisting();
            textBox1.AppendText(valueOfPort);
        }
    }
