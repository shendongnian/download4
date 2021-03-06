    namespace MyNamespace.MongoDB.Serializers
    {
        public class ComplexTypeSerializer : SerializerBase<object>
        {
            public override object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                var serializer = BsonSerializer.LookupSerializer(typeof(BsonDocument));
                var document = serializer.Deserialize(context, args);
                var bsonDocument = document.ToBsonDocument();
                var result = BsonExtensionMethods.ToJson(bsonDocument);
                return JsonConvert.DeserializeObject<IDictionary<string, object>>(result);
            }
    
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
            {
                var jsonDocument = JsonConvert.SerializeObject(value);
                var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(jsonDocument);
    
                var serializer = BsonSerializer.LookupSerializer(typeof(BsonDocument));
                serializer.Serialize(context, bsonDocument.AsBsonValue);
            }
        }
    }
