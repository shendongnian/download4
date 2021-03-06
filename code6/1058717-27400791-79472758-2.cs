    public abstract class TextContext
    {
        public int ID { get; set; }
        public int Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        List<Keyword> Keywords;
    
       public int PlusOne(int a){
           return a+1;
       }
    
    }
    public class Article:TextContext
    {
        public int ArticleID { get; set; }
        public bool IsReady { get; set; }
    }
    
    public class NewsArchive:TextContext
    {
        public int NewsArchiveID { get; set; }
    }
