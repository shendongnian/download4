    public class TimeExtension : MarkupExtension
    {
        System.Threading.Timer _timer = null;
        //DispatcherTimer _timer = null;
        public TimeExtension()
        {
        }
        public TimeExtension(int milliseconds)
        {
            Milliseconds = milliseconds;
        }
        public int Milliseconds { get; set; } = 250;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget provideValueTarget = 
                serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (provideValueTarget.TargetObject is DependencyObject targetobj)
            if (provideValueTarget.TargetProperty is DependencyProperty targetProp)
            {
                System.Threading.TimerCallback tick 
                        = new System.Threading.TimerCallback(o =>
                {
                    try
                    {
                        //  This is what worked in WPF:
                        //(targetobj as Control).Dispatcher.Invoke(() =>
                        //  I *think* this may work in Xamarin. Maybe. 
                        (targetobj as NSObject).InvokeOnMainThread(() =>
                        {
                            targetobj.SetValue(targetProp, DateTime.Now);
                        });
                    }
                    catch (Exception ex)
                    {
                        _timer.Dispose();
                        _timer = null;
                    }
                });
                _timer = new System.Threading.Timer(tick, null, 0, Milliseconds);
                //  WPF
                /*
                _timer = new DispatcherTimer();
                _timer.Interval = new TimeSpan(0, 0, 0, 0, Milliseconds);
                _timer.Tick += (s, e) =>
                {
                    try
                    {
                        targetobj.SetValue(targetProp, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        targetobj.SetValue(targetProp, ex.Message);
                        _timer.Stop();
                    }
                };
                _timer.Start();
                */
            }
            return DateTime.Now;
        }
    }
