    public static DateTime AddBusinessDays(DateTime date, int days)
    {
        int completeWeeks = days / 5;
        int extraDays = days % 5;
        DateTime firstGuess = date.AddDays(completeWeeks * 7 + extraDays);
        if (firstGuess.DayOfWeek == DayOfWeek.Saturday)
        {
            return firstGuess.AddDays(2);
        }
        else if (firstGuess.DayOfWeek == DayOfWeek.Sunday)
        {
            return firstGuess.AddDays(1);
        }
        else
        {
            return firstGuess;
        }
    }
