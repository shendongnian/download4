    public class RetryHandler : DelegatingHandler
    {
        // Strongly consider limiting the number of retries - "retry forever" is
        // probably not the most user friendly way you could respond to "the
        // network cable got pulled out."
        private const int MaxRetries = 3;
        public RetryHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        { }
    
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            for (int i = 0; i < MaxRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode) {
                    return response;
                }
            }
            
            return response;
        }
    }
    public class BusinessLogic
    {
        public void FetchSomeThingsSynchronously()
        {
            // ...
            // Consider abstracting this construction to a factory or IoC container
            using (var client = new HttpClient(new RetryHandler(new HttpClientHandler())))
            {
                myResult = client.PostAsync(yourUri, yourHttpContent).Result;
            }
            // ...
        }
    }
