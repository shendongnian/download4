    using (var ms = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(json)))
    {
       System.Runtime.Serialization.Json.DataContractJsonSerializer deserializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(MaterialJson));
       MaterialJson test = (MaterialJson)deserializer.ReadObject(ms);
    }
