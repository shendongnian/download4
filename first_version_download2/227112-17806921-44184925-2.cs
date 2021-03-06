    /// <summary>
    /// Author: Samuel Egger
    /// </summary>
    class Program
    {
        private static EventWaitHandle swappedWh = new EventWaitHandle(false, EventResetMode.AutoReset);
        private static object lockerA = new object();
        private static object lockerB = new object();
        private static int counter = 0;
        // The queues can be of any type which holds your data e.g. a struct or a class
        private static Queue<string> dataQueueA = new Queue<string>();
        private static Queue<string> dataQueueB = new Queue<string>();
        static void Main(string[] args)
        {
            Thread sendDataToClientThread = new Thread(SendDataToClient);
            Thread processDataThread = new Thread(ProcessData);
            
            sendDataToClientThread.IsBackground = false;
            processDataThread.Start();
            sendDataToClientThread.Start();
        }
        private static void ProcessData()
        {
            while (true)
            {
                Random rnd = new Random();
                string state = String.Format("Some data: {0}", rnd.Next(9999));
                lock (lockerA)
                {
                    Thread.Sleep(rnd.Next(1000));
                    dataQueueA.Enqueue(state);
                }
                // If the operations result is equal to 2, then the render thread is done
                // and is waitung for getting unblocked
                if (Interlocked.Increment(ref counter) == 2)
                {
                    counter = 0;
                    SwapQueues();
                    swappedWh.Set();
                }
                else
                {
                    swappedWh.WaitOne();
                }
            }
        }
        private static void SendDataToClient()
        {
            while (true)
            {
                Random rnd = new Random();
                lock (lockerB)
                {
                    // Send the data generated by the process data thread
                    while (dataQueueB.Count > 0)
                    {
                        string data = dataQueueB.Dequeue();
                        Thread.Sleep(rnd.Next(1000));
                        Console.WriteLine(String.Format("Sending data: {0}", data));
                    }
                }
                if (Interlocked.Increment(ref counter) == 2)
                {
                    counter = 0;
                    SwapQueues();
                    swappedWh.Set();
                }
                else
                {
                    swappedWh.WaitOne();
                }
            }
        }
        static void SwapQueues()
        {
            // Wait until both threads are "done" before swapping
            lock (lockerA)
            {
                lock (lockerB)
                {
                    Queue<string> tmpQueue = dataQueueA;
                    dataQueueA = dataQueueB;
                    dataQueueB = tmpQueue;
                }
            }
        }
    }
