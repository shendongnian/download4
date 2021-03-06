    private async Task<List<MyClass>> MyDeserializerFunAsync()
    {
        List<MyClass> book = new List<MyClass>();
        try
        {
           //I am taking my url from appsettings. myKey is my appsetting key. You can write direct your url.
           string url = (string)appSettings["mykey"];
           var request = HttpWebRequest.Create(url) as HttpWebRequest;
           request.Accept = "application/json;odata=verbose";
           var factory = new TaskFactory();
           var task = factory.FromAsync<WebResponse>(request.BeginGetResponse,request.EndGetResponse, null);
           var response = await task;
           Stream responseStream = response.GetResponseStream();
           string data;
           using (var reader = new System.IO.StreamReader(responseStream))
           {
               data = reader.ReadToEnd();
           }
           responseStream.Close();
           DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<MyClass>));
           MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
           book = (List<MyClass>)json.ReadObject(ms);
           return book;
       }
    } 
