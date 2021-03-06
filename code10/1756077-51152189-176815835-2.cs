    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://172.25.1.53:9891");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        string autenticacion = "?username=" + email + "&password=" + clave + "&grant_type=password";
        HttpResponseMessage response = await client.PostAsync(client.BaseAddress + autenticacion, new StringContent(autenticacion));
    
        response.EnsureSuccessStatusCode();
    
        string JSONAutenticacion = await response.Content.ReadAsStringAsync();
    }
