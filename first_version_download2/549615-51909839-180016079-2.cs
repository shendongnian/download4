    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq ;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main()
            {
                XDocument doc = XDocument.Load(FILENAME);
                string name = "first";
                Dictionary<string, string> dict = doc.Descendants("setting")
                    .Where(x => (string)x.Element("name") == name).FirstOrDefault()
                    .Elements().GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
     
    }
