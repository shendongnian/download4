    public class Foo
    {
        Windows.UI.Xaml.DispatcherTimer dispatcherTimer;
        public void StartTimers()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
    
        void dispatcherTimer_Tick(object sender, object e)
        {
            // execute repeating task here
        }
    }
