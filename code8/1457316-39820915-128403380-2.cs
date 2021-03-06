    public class Reported
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public int BlockerId { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public int ForfeitCount { get; set; }
        public int RewardCount { get; set; }
    }
    public class List
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public int UserId { get; set; }
        public string UID { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Answer { get; set; }
        public string Comment { get; set; }
        public object ProductTitle { get; set; }
        public int CommentId { get; set; }
        public string Logo { get; set; }
        public int Date { get; set; }
        public int AnswerDate { get; set; }
        public bool AnswerEdit { get; set; }
        public bool CommentEdit { get; set; }
        public int ForfeitCount { get; set; }
        public int RewardCount { get; set; }
        public int ThisCountReport { get; set; }
        public List<Reported> Reported { get; set; }
        public int Gem { get; set; }
    }
    public class Result
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public int dateTime { get; set; }
        public List<List> list { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public Result Result { get; set; }
        public string StatusCode { get; set; }
        public object Description { get; set; }
    }
