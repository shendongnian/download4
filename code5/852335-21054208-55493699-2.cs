    private void Send()
    {
        SerialPort sp = new SerialPort();
        sp.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
        sp.PortName = "COM4";//choose your port wisely
        sp.BaudRate = 9600;
        sp.Parity = Parity.None;
        sp.Open();
    
        // Set the GSM modem to Text Mode
        sp.WriteLine("AT+CMGF=1"+Environment.NewLine);
        // Specifying mobile number
        sp.WriteLine(string.Format("AT+CMGS=\"+91{0}\"{1}", textBox1.Text, Environment.NewLine));
        // Specifying sms body
        sp.WriteLine(textBox2.Text + (char)26 + Environment.NewLine);
        MessageBox.Show("Message sent successfully");
    }
    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string modemResult = sp.ReadExisting();
        this.yourTextBox.Text += modemResult;
    }
