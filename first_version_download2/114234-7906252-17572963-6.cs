    public class Pagination
    {
        [XmlArray("pages"), XmlArrayItem("page")]
        public ResultsPage[] Pages { get; set; }
        [XmlElement("total-pages")]
        public int TotalPages { get; set; }
    }
