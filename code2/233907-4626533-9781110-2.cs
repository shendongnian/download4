    public static class DateTimeHelper
    {
        public static string MyEditor(this HtmlHelper helper, DateTime date)
        {
            if (date.Equals(DateTime.MinValue))
            {
                // return your an empty input: helper.TextBox ...
            }
            // return helper.EditorFor your datetime
        }
    }
