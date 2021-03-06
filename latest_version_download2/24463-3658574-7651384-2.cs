    using System;
    using System.Xml;
    
    class Program
    {
        static void Foo(object o)
        {
            Console.WriteLine("object overload");
        }
    
        static void Foo(XmlNode node)
        {
            Console.WriteLine("XmlNode overload");
        }
    
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root><child/></root>");
    
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Foo(node);
            }
            foreach (var node in doc.DocumentElement.ChildNodes)
            {
                // oops! node is now of type object!
                Foo(node);
            }
        }
    }
