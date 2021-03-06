    public static class SeriaizationExtensionMethods
        {
            /// <summary>
            /// Serializes the object.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="toSerialize">To serialize.</param>
            /// <returns></returns>
            public static string SerializeObject<T>(this T toSerialize)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
            /// <summary>
            /// Serializes the object.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="toSerialize">To serialize.</param>
            /// <param name="path">The path.</param>
            public static void SerializeObject<T>(this T toSerialize, string path)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, toSerialize);
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.Write(textWriter.ToString());
                }
            }
            public static T Deserialize<T>(string xml)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StringReader(xml);
                return (T)serializer.Deserialize(textReader);
            }
            public static T Deserialize<T>(this T original, string path)
            {
                string xml = string.Empty;
                using (StreamReader sr = new StreamReader(path))
                {
                    xml = sr.ReadToEnd();
                }
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StringReader(xml);
                return (T)serializer.Deserialize(textReader);
            }
        }
