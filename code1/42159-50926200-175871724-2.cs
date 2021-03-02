    namespace System.Globalization
    {
        public static class ISOWeek
        {
            public static int GetWeekOfYear(DateTime date);
            public static int GetWeeksInYear(int year);
            public static int GetYear(DateTime date);
            public static DateTime GetYearEnd(int year);
            public static DateTime GetYearStart(int year);
            public static DateTime ToDateTime(int year, int week, DayOfWeek dayOfWeek);
        }
    }
