    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string AlternateName { get; set; }
        [JsonConverter(typeof(StringTruncatingConverter))]
        public string Description { get; set; }
        [JsonIgnore]
        public string Color { get; set; }
    }
