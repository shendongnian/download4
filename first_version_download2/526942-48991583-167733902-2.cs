    public class RowsConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var settings = new JsonSerializerSettings()
    		{
    			ContractResolver = new DefaultContractResolver()
    		};
    		writer.WriteRawValue(JsonConvert.SerializeObject(value, settings));
    	}
    }
