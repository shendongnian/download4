    public class FJson : JsonConverter
    {
        bool CannotWrite { get; set; }
        public override bool CanWrite { get { return !CannotWrite; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t;
            using (new PushValue<bool>(true, () => CannotWrite, (canWrite) => CannotWrite = canWrite))
            {
                t = JToken.FromObject(value, serializer);
            }
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
                return;
            }
            JObject o = (JObject)t;
            writer.WriteStartObject();
            WriteJson(writer, o);
            writer.WriteEndObject();
        }
        private void WriteJson(JsonWriter writer, JObject value)
        {
            foreach (var p in value.Properties())
            {
                if (p.Value is JObject)
                    WriteJson(writer, (JObject)p.Value);
                else
                    p.WriteTo(writer);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType,
           object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return true; // works for any type
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Func<T> getValue;
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.getValue = getValue;
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
