        string result;
        using (var httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://domain.com");
            request.Content = new StringContent(Serialize(obj), Encoding.UTF8, "text/xml");
            var response = await httpClient.SendAsync(request);
            result = response.Content.ReadAsStringAsync().Result;
        }
    
       XmlReader rssFeed = XmlReader.Create(new StringReader(result));
