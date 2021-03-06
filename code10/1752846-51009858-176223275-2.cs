    public void ConfigureServices(IServiceCollection services) {
        //...
        
        SetUpHttpClients(services);
        //...
        
        services.AddMvc();
    }
    
    public void SetUpHttpClients(IServiceCollection services) {
        
        var fileExists = File.Exists(certificatePath);
        if (!fileExists)
            throw new ArgumentException(certificatePath);
        var certificate = new X509Certificate2(certificatePath, certPwd);
        
        services.AddHttpClient("TestClient", client => {
            client.BaseAddress = new Uri(baseApi);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
        })
        .ConfigurePrimaryHttpMessageHandler(() => {
            var handler = new HttpClientHandler {
                CookieContainer = cookieContainer
            };
            handler.ClientCertificates.Add(certificate);
            return handler;
        });
        
    }
    
