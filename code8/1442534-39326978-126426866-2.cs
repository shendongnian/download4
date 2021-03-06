    public class RootObject
    {
        public class GameStats
        {
            private GameStats() { }
        }
        public class Request
        {
            private Request() { }
        }
        public class AverageStats
        {
            private AverageStats() { }
        }
        public class OverallStats
        {
            private OverallStats() { }
        }
        public Request _request { get; set; }
        public AverageStats average_stats { get; set; }
        public string battletag { get; set; }
        public GameStats game_stats { get; set; }
        public OverallStats overall_stats { get; set; }
        public string region { get; set; }
    }
