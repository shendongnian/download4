    [DataContract(Name = "GenericType")]
    [KnownType(typeof(GetKnownType))]
    public class GenericType<T>
    {
        [DataMember]
        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }
        private static Type[] GetKnownType()
        {
          Type[] t = new Type[1];
          t[0] = typeof(typeof(MyType));
          return t;
        }
    }
