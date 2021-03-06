    public List<T> GetData<T>(string ControllersName)
    {         
         string Url = Settings.baseURLAddress + ControllersName;
         var request = (HttpWebRequest)HttpWebRequest.Create(Url);
         DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
         return serializer.ReadObject(request.GetResponse().GetResponseStream());
    }
