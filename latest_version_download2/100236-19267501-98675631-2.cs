    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    HttpResponseMessage response = await client.GetAsync(endpoint);
    Stream stream = await response
        .Content.ReadAsStreamAsync().ConfigureAwait(false);
    response.EnsureSuccessStatusCode();
