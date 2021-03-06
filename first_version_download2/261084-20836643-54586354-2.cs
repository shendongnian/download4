    public class DateRange
    {
        public DateRange(DateTime start, DateTime end)
        {
            if (start > end) 
                throw new ArgumentException();
            Start = start;
            End = end;
        }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public TimeSpan Span { get { return End - Start; } }
        public bool Includes(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }
        public DateRange Intersect(DateRange range)
        {
            if (range.Includes(Start))
                return new DateRange(Start, (End < range.End) ? End : range.End);
            if (range.Includes(End))
                return new DateRange(range.Start, End);
            return null;
        }
    }
