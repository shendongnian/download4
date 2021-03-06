    using (var client = new HttpClient())
    {
        var values = new Dictionary<string, string>
        {
           { "username", username },
           { "password", password }
        };
    
        var content = new FormUrlEncodedContent(values);
        var response = await client.PostAsync(sURL, content);
        if (response.IsSuccessStatusCode)
        {    
            var response = await response.Content.ReadAsString();
            // then repeat for the next request
        }
    }
