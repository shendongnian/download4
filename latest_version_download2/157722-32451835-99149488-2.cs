    public partial class Form1 : Form
    {
        public string Result = "";
        private int timeOut = 10000;
    
        MyServer server = new MyServer();
        AutoResetEvent res = new AutoResetEvent(false);
        public Form1()
        {
            InitializeComponent();   
            server.RecieveMessage += new MyServer.RecieveMessageEventHandler(server_RecieveMessage);
        }
    
        void server_RecieveMessage(object sender, string message)
        {
            Result = message;
            res.Set();
        }
    
    
        public string SendCommand(string Command)
        {        
            server.Send(Command);
            res.WaitOne(timeOut);
    
            //wait for 10 seconds or untill RecieveMessage event raised
    
    
            //process Data is recieved
    
            server.Send(AnotherCommand);
            res.WaitOne(timeOut);    
            //wait for 10 seconds or untill RecieveMessage event raised
    
    
            //process Data is recieved
    
            ....
    
                //till i get what i want
            return Result;
        }
