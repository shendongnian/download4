        /// <summary>Serialises an object of type T in to an xml string</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="objectToSerialise">Object to serialise</param>
    /// <returns>A string that represents Xml, empty oterwise</returns>
    public static string XmlSerialise<T>(this T objectToSerialise) where T : class, new() 
    {
      var serialiser = new XmlSerializer(typeof(T));
      string xml;
      using (var memStream = new MemoryStream())
      {
        using (var xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8))
        {
          serialiser.Serialize(xmlWriter, objectToSerialise);
          xml = Encoding.UTF8.GetString(memStream.GetBuffer());
        }
      }
      xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
      xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
      return xml;
    }
    /// <summary>Deserialises an xml string in to an object of Type T</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="xml">Xml as string to deserialise from</param>
    /// <returns>A new object of type T is successful, null if failed</returns>
    public static T XmlDeserialise<T>(this string xml) where T : class, new()
    {
      var serialiser = new XmlSerializer(typeof(T));
      T newObject;
      using (var stringReader = new StringReader(xml))
      {
        using (var xmlReader = new XmlTextReader(stringReader))
        {
          try
          {
            newObject = serialiser.Deserialize(xmlReader) as T;
          }
          catch (InvalidOperationException) // String passed is not Xml, return null
          {
            return null;
          }
        }
      }
      return newObject;
    }
