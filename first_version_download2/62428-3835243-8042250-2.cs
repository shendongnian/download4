	public TimeSpan Compute(DateTime start, DateTime end)
	{
		// constant start / end times per day
		TimeSpan dayStart = new TimeSpan(7, 0, 0);
		TimeSpan dayEnd = new TimeSpan(19, 0, 0);
	
		if( start >= end )
		{
			throw new Exception("invalid date range");
		}
		
		// total # of weeks
		int completeWeeks = (end - start).TotalDays / 7;
		
		// starting total
		TimeSpan total = TimeSpan.FromDays(completeWeeks * 12 * 5);
		
		// adjust the start date to be exactly "completeWeeks" past its original start
		start = start.AddDays(completeWeeks * 7);
		
		// walk days from the adjusted start start to end (at most 6), accumulating time as we can...
		for(
			// start at midnight
			DateTime dt = start.Date;
			
			// continue while there is time left
			dt < end;
			
			// increment 1 day at a time
			dt = dt.AddDays(1)
		)
		{
			// ignore weekend
			if( (dt.DayOfWeek == DayOfWeek.Saturday) ||
				 (dt.DayOfWeek == DayOfWeek.Sunday) )
			{
				continue;
			}
			
			// get the start/end time for each day...
			// typically 7am / 7pm unless we are at the start / end date
			TimeSpan dtStartTime = ((dt == start.Date) && (start.TimeOfDay > dayStart)) ?
				start.TimeOfDay : dayStart;
			TimeSpan dtEndTime = ((dt == end.Date) && (end.TimeOfDay < dayEnd)) ?
				end.TimeOfDay : dayEnd;
			
			if( dtStartTime < dtEndTime )
			{
				total = total.Add(dtEndTime - dtStartTime);
			}
		}
		
		return total;
	}
