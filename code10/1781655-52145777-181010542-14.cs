    public static class UpdaterEvent 
    {
        public static event EventHandler DataUpdated;
    
        public static void PublishDataUpdated(EventArgs args) 
        {
            var evt = DataUpdated;
            if (evt != null)
                evt(null, args);
        }
    }
