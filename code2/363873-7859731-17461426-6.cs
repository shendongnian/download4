    public class MySynonyms : Lucene.Net.SynonymEngine.ISynonymEngine
    {
        public IEnumerable<string> GetSynonyms(string word)
        {
            if (word == "quick") return  new List<string>{"fast"};
            return new List<string>();
        }
    }
    SynonymAnalyzer sa = new SynonymAnalyzer(new MySynonyms());
