    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlstr =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<anyType xmlns:q1=\"http://www.w3.org/2001/XMLSchema\"" +
                          " d1p1:type=\"q1:string\"" +
                          " xmlns:d1p1=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                          "floatnumber" +
                   "</anyType>";
                XDocument doc = XDocument.Parse(xmlstr);
                XElement anyType = (XElement)doc.FirstNode;
                XNamespace ns = anyType.Name.Namespace;
                string floatnumber = anyType.Value;
            }
        }
    }
    ​
