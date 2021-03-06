        void Main()
    {
    	var a = Newtonsoft.Json.JsonConvert.DeserializeObject( "{     \"bool\": {\"must\": [{\"Term\": {\"number\": 5}},{\"Match\": {\"name\": \"xxx\"}}]}}",typeof(TestClass)).Dump();
     	JsonConvert.SerializeObject(a).Dump();
    }
    
    public class TestClass
    {
    	[JsonProperty(PropertyName = "bool", NullValueHandling = NullValueHandling.Ignore)]
    	public BaseFilterType Bool { get; set; }
    }
    
    public class BaseFilterType
    {
    	[JsonProperty(PropertyName = "must", NullValueHandling = NullValueHandling.Ignore)]
    	public List<BaseTypeQuery> Must { get; set; }
    }
    public class BaseTypeQuery
    {
    	[JsonProperty(PropertyName = "term", NullValueHandling = NullValueHandling.Ignore)]
    	public Dictionary<string, object> Term { get; set; }
    	[JsonProperty(PropertyName = "match", NullValueHandling = NullValueHandling.Ignore)]
    	public Dictionary<string, object> Match { get; set; }
    }
