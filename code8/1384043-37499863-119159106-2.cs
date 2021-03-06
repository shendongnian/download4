    static bool ReleaseMutex = false;
    static bool bThread1Running = false;
    static bool bQuit = false;
    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Thread1));
        while (!bThread1Running)
            Thread.Sleep(100);
        ThreadPool.QueueUserWorkItem(new WaitCallback(Thread2));
        while (!bQuit)
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    ReleaseMutex = true;
                    break;
                case '2':
                    bQuit = true;
                    break;
            }
        }
        Console.ReadLine();
    }
    static void Thread1(object data)
    {
        using (EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset, "TestEvent"))
        {
            bThread1Running = true;
            Console.WriteLine("Thread 1 created TestEvent.");
            while (!ReleaseMutex)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1 is waiting to signal TestEvent. Press 1 to do so.");
            }
            Console.WriteLine("Thread 1 is signaling TestEvent and exiting.");
            ewh.Set();
        }
    }
    static void Thread2(object data)
    {
        WaitHandle wh = EventWaitHandle.OpenExisting("TestEvent");
        RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(wh, new WaitOrTimerCallback(Thread3), null, Timeout.Infinite, true);
        Console.WriteLine("Thread 2 registered thread 3 run when TestEvent is signaled.");
        while(!bQuit)
        {
            Console.WriteLine("Thread 2 is running.");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Thread 2 is exiting");
    }
    static void Thread3(object data, bool t)
    {
        while(!bQuit)
        {
            Console.WriteLine("Thread 3 is running");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Thread 3 is exiting");
    }
