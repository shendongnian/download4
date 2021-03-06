    public class TupleListConverter<U, V> : Newtonsoft.Json.JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Tuple<U, V>) == objectType;
		}
		public override object ReadJson(
			Newtonsoft.Json.JsonReader reader,
			Type objectType,
			object existingValue,
			Newtonsoft.Json.JsonSerializer serializer)
		{
			if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
				return null;
			var jArray = Newtonsoft.Json.Linq.JArray.Load(reader);
            var target = new List<Tuple<U, V>>();
            foreach (var childJArray in jArray.Children<Newtonsoft.Json.Linq.JArray>())
            {
				var tuple = new Tuple<U, V>(
                    childJArray[0].ToObject<U>(),
                    childJArray[1].ToObject<V>()
                );
                target.Add(tuple);
			}
			return target;
		}
		public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}
    }
