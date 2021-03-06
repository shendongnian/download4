    public struct DateTimeWithZone
    {
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;
        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            utcDateTime = dateTime.ToUniversalTime();
            this.timeZone = timeZone;
        }
        public DateTime UniversalTime { get { return utcDateTime; } }
        public TimeZoneInfo TimeZone { get { return timeZone; } }
        public DateTime LocalTime
        { 
            get 
            { 
                return TimeZoneInfo.ConvertTime(utcTime, timeZone); 
            }
        }        
    }
