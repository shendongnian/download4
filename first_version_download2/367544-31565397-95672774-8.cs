    public class Form1
    {
        PCBClass PCB; // The name of that class I don't know from your code
        public Form1()
        {
            PCB = new PCBClass();
            PCB.MessageReceived += MessageReceived;
        } 
        public void MessageReceived(object sender, PCBClass.MessageReceivedEventArgs e)
        {
            analyzeIncomingMessage(e.Data);
        }
    
        public void analyzeIncomingMessage(byte[] data)
        {
            if (data[0] == 63)
            {
                setBoardDesignator(data[1], data[2]);
            }
        }
    }
