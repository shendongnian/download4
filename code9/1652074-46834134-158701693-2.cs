    static DateTime NthWeekDay(DateTime value, int n, DayOfWeek weekday) {
        var w = ((int)value.DayOfWeek);
            
        return value.AddDays(-(w % 7) + (((int)weekday) % 7) + (7 * n));
    }
    static IEnumerable<DateTime> GenerateHolidays(DateTime value) {
        yield return new DateTime(value.Year, 1, 1); // New Year's Day
        yield return NthWeekDay(new DateTime(value.Year, 1, 6), 2, DayOfWeek.Monday); // Martin Luther King Jr. Day
        yield return NthWeekDay(new DateTime(value.Year, 2, 6), 2, DayOfWeek.Monday); // Presidents' Day
        yield return NthWeekDay(new DateTime(value.Year, 5, 31), 0, DayOfWeek.Monday); // Memorial Day
        yield return new DateTime(value.Year, 7, 4); // Independence Day
        yield return NthWeekDay(new DateTime(value.Year, 9, 6), 0, DayOfWeek.Monday); // Labor Day
        yield return NthWeekDay(new DateTime(value.Year, 10, 6), 1, DayOfWeek.Monday); // Columbus Day
        yield return new DateTime(value.Year, 11, 11); // Veterans' Day
        yield return NthWeekDay(new DateTime(value.Year, 11, 3), 3, DayOfWeek.Thursday); // Thanksgiving Day
        yield return new DateTime(value.Year, 12, 25); // Christmas Day
    }
