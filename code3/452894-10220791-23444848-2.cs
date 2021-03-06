    public class ViewModel : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;
         public string TimeElapsed {get;set;}
         public void StartTimer()
         {
              timer = new DispatcherTimer();
              timer.Tick += dispatcherTimerTick_;
              timer.Interval = new TimeSpan(0,0,0,0,1);
              stopWatch.Start();
              timer.Start();
         }
         private DisptacherTimer timer;
         private StopWatch stopWatch;
         private void dispatcherTimerTick_(object sender, EventArgs e)
         {
             TimeElapsed = stopWatch.Elapsed.TotalMilliseconds; // Format as you wish
             PropertyChanged(this, new PropertyChangedEventArgs("TimeElapsed")); 
         }
    }
