    public class XmlVariantFactory
    {
        private readonly Dictionary<string, Type> _xmlRoots;
        public XmlVariantFactory() : this(Assembly.GetExecutingAssembly().GetTypes())
        {
        }
        public XmlVariantFactory(IEnumerable<Type> types)
        {
            _xmlRoots = types
                        .Select(t => new {t, t.GetCustomAttribute<XmlRootAttribute>()?.ElementName})
                        .Where(x => !string.IsNullOrEmpty(x.ElementName))
                        .ToDictionary(x => x.ElementName, x => x.t);
        }
        public Type GetSerializationType(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    return _xmlRoots[reader.LocalName];
                }
            }
            throw new ArgumentException("No known root type found for passed XML");
        }
    }
