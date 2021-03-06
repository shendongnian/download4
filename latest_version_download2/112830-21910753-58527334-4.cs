    public static class DateTimeHelper
    {
        public static void ForEach(DateTime from, DateTime to, Action<DateTime> action)
        {
            if (to < from)
                for (DateTime date = from; date.Date >= to.Date; date = date.AddDays(-1))
                    action.Invoke(date);
            else
                for (DateTime date = from; date.Date <= to.Date; date = date.AddDays(1))
                    action.Invoke(date);
        }
    }
