    public class Foos
    {       
        public List<Foo> FooList { get; set; }
    }
    public class Foo
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xmlAttributeForFoos = new XmlAttributes { XmlRoot = new XmlRootAttribute(ConfigurationManager.AppSettings["someFoosValue"]), XmlType = new XmlTypeAttribute(ConfigurationManager.AppSettings["someFoosValue"]) };
            var xmlAttributeForFooList = new XmlAttributes();
            var xmlAttributeForFoo = new XmlAttributes();
            xmlAttributeForFooList.XmlElements.Add(new XmlElementAttribute(ConfigurationManager.AppSettings["someFooValue"]));
            xmlAttributeForFoo.XmlElements.Add(new XmlElementAttribute(ConfigurationManager.AppSettings["someFooNameValue"]));
             var overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(Foos), xmlAttributeForFoos);
            overrides.Add(typeof(Foos), "FooList", xmlAttributeForFooList);
            overrides.Add(typeof(Foo), "Name", xmlAttributeForFoo);
            XmlSerializer serializer = new XmlSerializer(typeof(Foos), overrides);
            var foos = new Foos
            {
                FooList = new List<Foo>
                {
                    new Foo{Name = "FooName"}
                }
            };
            using (var stream = File.Open("file.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, foos);
            }
        }
    }
