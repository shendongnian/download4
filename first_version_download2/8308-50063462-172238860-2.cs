    public static class ListViewExtensions
    {
        public static void SetDoubleBuffered(this ListView listView, bool value)
        {
            listView.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(listView, value);
        }
    }
