    public class SearchArticles
    {
        [XmlArray("articles")]
        [XmlArrayElement("article", Type = typeof(Article))]
        public ArticleHelper articles { get; set; }
    }
    public class Article
    {
        [XmlAttribute("hits")]
        public int hits { get; set }
    
        public long id { get; set; }
        public string partner { get; set; }
        public string number { get; set; }
        public long number_is_generated { get; set; }
        public string status { get; set; }
        public long company_id { get; set; }
    }
