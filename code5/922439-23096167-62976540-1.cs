    HttpWebRequest request = WebRequest.CreateHttp("" + url);
    //we could move the content-type into a function argument too.
    request.ContentType = "application/x-www-form-urlencoded";
    request.Method = "POST";
    postParams.Add("oauth_token", ""); // where do I add this to the request??
    try
    {
        using (var stream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null))
        {
            // For some reason this seems to be the only way in windows phone of doing this?
            var stream = await request.GetRequestStreamAsync();
            byte[] jsonAsBytes = Encoding.UTF8.GetBytes(string.Join("&", postParams.Select(pp => pp.Key + "=" + pp.Value)));
            await stream.WriteAsync(jsonAsBytes, 0, jsonAsBytes.Length);
        }
        HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
        Debug.WriteLine(response.ContentType);
        System.IO.Stream responseStream = response.GetResponseStream();
        string data;
        using (var reader = new System.IO.StreamReader(responseStream))
        {
            data = reader.ReadToEnd();
        }
        responseStream.Close();
        return data;
    }
