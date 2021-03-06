    [DataContract]
    public class Document
    {
        [BsonId]
        public ObjectId _id { get; set; }
    
        [DataMember]
        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }
