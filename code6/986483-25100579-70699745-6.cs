    public class ScheduleRequest
    {
        private readonly DateTime _currentDate;
        public ScheduleRequest()
        {
            _currentDate = DateTime.Now;
        }
        public ScheduleRequest(DateTime currentDate)
        {
            _currentDate = currentDate;
        }
        public DateTime CurrentDate
        {
            get { return _currentDate; }
        }
        public DateTime BaseDate { get; set; }
        public Schedule Schedule { get; set; }
        public double IntervalMillis { get { return (double)this.Schedule * this.Interval; } }
        public int Interval { get; set; }
    }
