    public class ModelState
    {
        public IList<string> user_FirstName{ get; set; }
    }
    public class Example
    {
        public string Message { get; set; }
        public ModelState ModelState { get; set; }
    }
