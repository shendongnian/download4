    using System.Collections.Generic;
    using System.Configuration;
    using System.Xml;
    
    public class ConfigurationTextElement<T> : ConfigurationElement
    {
        private T _value;
        protected override void DeserializeElement(XmlReader reader, 
                                bool serializeCollectionKey)
        {
            _value = (T)reader.ReadElementContentAs(typeof(T), null);
        }
        public T Value
        {
            get { return _value; }
        }
    }
