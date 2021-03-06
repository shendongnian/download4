    [Serializable]
    public sealed class ExtensionDataObjectSerializationProxy : IExtensibleDataObject, ISerializable
    {
        [DataContract(Name="ExtensionData", Namespace="")]
        sealed class ExtensionDataObjectSerializationContractProxy : IExtensibleDataObject
        {
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            #region IExtensibleDataObject Members
            public ExtensionDataObject ExtensionData
            {
                get
                {
                    return extensionDataField;
                }
                set
                {
                    extensionDataField = value;
                }
            }
            #endregion
        }
        public ExtensionDataObjectSerializationProxy() { }
        public ExtensionDataObjectSerializationProxy(SerializationInfo info, StreamingContext context)
        {
            var xml = (string)info.GetValue("ExtensionData", typeof(string));
            if (!string.IsNullOrEmpty(xml))
            {
                var wrapper = DataContractSerializerHelper.LoadFromXML<ExtensionDataObjectSerializationContractProxy>(xml);
                this.ExtensionData = (wrapper == null ? null : wrapper.ExtensionData);
            }
        }
        #region ISerializable Members
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (ExtensionData != null)
            {
                var xml = DataContractSerializerHelper.GetXml(new ExtensionDataObjectSerializationContractProxy { ExtensionData = this.ExtensionData });
                info.AddValue("ExtensionData", xml);
            }
        }
        #endregion
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataField;
            }
            set
            {
                extensionDataField = value;
            }
        }
        #endregion
    }
    public static class DataContractSerializerHelper
    {
        public static string GetXml<T>(T obj, DataContractSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(textWriter))
                {
                    (serializer ?? new DataContractSerializer(typeof(T))).WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static T LoadFromXML<T>(string xml, DataContractSerializer serializer = null)
        {
            using (var stream = GenerateStreamFromString(xml))
            {
                return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(stream);
            }
        }
    }
