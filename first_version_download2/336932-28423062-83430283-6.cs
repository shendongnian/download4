    private sealed class Period : IEquatable<Period>
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Period(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
		public double TotalHours
		{
			get
			{
				return this.EndTime.Subtract(this.StartTime).TotalHours;
			}
		}
		
        public override bool Equals(object obj)
        {
            if (obj is Period)
                return Equals((Period)obj);
            return false;
        }
        public bool Equals(Period obj)
        {
            if (obj == null)
                return false;
            if (!EqualityComparer<DateTime>.Default.Equals(
                        this.StartTime, obj.StartTime))
                return false;
            if (!EqualityComparer<DateTime>.Default.Equals(
                        this.EndTime, obj.EndTime))
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= EqualityComparer<DateTime>.Default
                .GetHashCode(this.StartTime);
            hash ^= EqualityComparer<DateTime>.Default
                .GetHashCode(this.EndTime);
            return hash;
        }
        public override string ToString()
        {
            return String.Format("{{ StartTime = {0}, EndTime = {1} }}",
                this.StartTime, this.EndTime);
        }
        public IEnumerable<Period> Remove(Period period)
        {
            if (period.StartTime <= this.StartTime)
            {
                if (period.EndTime <= this.StartTime)
                    yield return this;
                else if (period.EndTime >= this.EndTime)
                    yield break;
                else
                    yield return new Period(period.EndTime, this.EndTime);
            }
            else if (period.StartTime < this.EndTime)
            {
                yield return new Period(this.StartTime, period.StartTime);
                if (period.EndTime < this.EndTime)
                {
                    yield return new Period(period.EndTime, this.EndTime);
                }
            }
            else
                yield return this;
        }
		
		public IEnumerable<Period> Remove(IEnumerable<Period> periods)
        {
			return Remove(new [] { this }, periods);
        }
		
		private static IEnumerable<Period> Remove(IEnumerable<Period> selfs, IEnumerable<Period> periods)
        {
			if (periods == null || periods.IsEmpty())
			{
				return Enumerable.Empty<Period>();
			}
			else
			{
				var period = periods.First();
				var nexts =
					from s in selfs
					from ss in s.Remove(period)
					select ss;
				return periods.Skip(1).Any() ? Remove(nexts, periods.Skip(1)) : nexts;
			}
        }
    }
