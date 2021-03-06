    [WebService(Namespace = "http://msdnmagazine.com/ws")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [GenerateScriptType(typeof(Object1))]
    [GenerateScriptType(typeof(Object2))]
    [ScriptService]
    public class StockQuoteService : WebService
    {
        static Random _rand = new Random(Environment.TickCount);
        [WebMethod]
        public int GetStockQuote(string symbol)
        {
            return _rand.Next(0, 120);
        }
    }
