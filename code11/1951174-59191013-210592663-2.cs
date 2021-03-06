      string source = @"0812";
      int SystemYear = 19;
      DateTime date = DateTime.ParseExact(source, "MMdd", CultureInfo.InvariantCulture);
      // SystemYear > 80 : Let's treat 80 as 1980, but 79 as 2079
      date = new DateTime(SystemYear > 1000 
        ? SystemYear 
        : SystemYear > 80 ? SystemYear + 1900 : SystemYear + 2000, 
          date.Month,
          date.Day);
      // "12-AUG-19"
      string result = date.ToString("dd'-'MMM'-'yy", CultureInfo.InvariantCulture).ToUpper();
