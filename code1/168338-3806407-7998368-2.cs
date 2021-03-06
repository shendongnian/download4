    public class DynamicJsonObject : DynamicObject
    {
        private IDictionary<string, object> Dictionary { get; set; }
        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            Dictionary = dictionary;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!Dictionary.TryGetValue(binder.Name, out result))
                return false;
            var dictionary = result as IDictionary<string, object>;
            if (dictionary != null)
            {
                result = new DynamicJsonObject(dictionary);
                return true;
            }
            var arrayList = result as ArrayList;
            if (arrayList != null && arrayList.Count > 0)
            {
                if (arrayList[0] is IDictionary<string, object>)
                    result = new List<DynamicJsonObject>(arrayList.ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
                else
                    result = new List<object>(arrayList.Cast<object>());
            }
            return true;
        }
    }
    public class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            return type == typeof (object) ? new DynamicJsonObject(dictionary) : null;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
        }
    }
