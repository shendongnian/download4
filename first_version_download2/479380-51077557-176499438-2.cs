     DayOfWeek Day = DateTime.Now.DayOfWeek;
     int Days = Day - DayOfWeek.Monday; //here you can set your Week Start Day
     DateTime WeekStartDate = DateTime.Now.AddDays(-Days);
     DateTime WeekEndDate1 = WeekStartDate.AddDays(1);
     DateTime WeekEndDate2 = WeekStartDate.AddDays(2);
     DateTime WeekEndDate3 = WeekStartDate.AddDays(3);
     DateTime WeekEndDate4 = WeekStartDate.AddDays(4);
     DateTime WeekEndDate5 = WeekStartDate.AddDays(5);
     DateTime WeekEndDate6 = WeekStartDate.AddDays(6);
