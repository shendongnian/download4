	public class RunInfoRequestType 
	{
		public int Id {get; private set;}
		public string DisplayName {get; set;}
        protected static readonly IDictionary<int,RunInfoRequestType> values = new Dictionary<int,RunInfoRequestType>();
		protected RunInfoRequestType (int id, string displayName)
		{
			this.Id = id;
			this.DisplayName = displayName;
            values.Add(id, this);
		}
		public static readonly RunInfoRequestType Text1 = new RunInfoRequestType(1, "text1");
		public static readonly RunInfoRequestType Text2 = new RunInfoRequestType(2, "text2");
		public static readonly RunInfoRequestType Text3 = new RunInfoRequestType(3, "text3");
		public static readonly RunInfoRequestType Text4 = new RunInfoRequestType(4, "text4");
		public static readonly RunInfoRequestType Text5 = new RunInfoRequestType(5, "text5");
		public static readonly RunInfoRequestType Text6 = new RunInfoRequestType(6, "text6");
		public static readonly RunInfoRequestType Text7 = new RunInfoRequestType(7, "text7");
		public static readonly RunInfoRequestType Text8 = new RunInfoRequestType(8, "text8");
        public static implicit operator int(RunInfoRequestType runInfoRequestType)
        {
            return runInfoRequestType.Id;
        }
        public static implicit operator RunInfoRequestType(int id)
        {
            RunInfoRequestType runInfoRequestType ;
            values.TryGetValue(id, out runInfoRequestType);
            return runInfoRequestType ;
        }
        public override string ToString()
        {
            return this.DisplayName;
        }
	}
	//set text3's display name to string text
	RunInfoRequestType.Text3.DisplayName = text;
