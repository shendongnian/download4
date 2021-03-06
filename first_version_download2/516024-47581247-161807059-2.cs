    public class Page
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Error { get; set; }
    }
    public class Label
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class RootObject
    {
        public List<Page> pages { get; set; }
        public List<Label> labels { get; set; }
    }
