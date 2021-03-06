    public static class XmlTypeExtensions
    {
        public static string RootXmlElementName(this Type type)
        {
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                return xmlRoot.ElementName;
            return type.Name;
        }
        public static string RootXmlElementNamespace(this Type type)
        {
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.Namespace))
                return xmlRoot.Namespace;
            return string.Empty;
        }
    }
    public static class XObjectExtensions
    {
        static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, NoStandardXmlNamespaces());
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializerNamespaces ns)
        {
            return obj.SerializeToXElement(null, ns);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
        public static T Deserialize<T>(this XContainer element)
        {
            return element.Deserialize<T>(new XmlSerializer(typeof(T)));
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                object result = serializer.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
