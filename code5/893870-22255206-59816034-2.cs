    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private HttpResponseMessage _response;
        public static HttpMessageHandler GetHttpMessageHandler( string content, HttpStatusCode httpStatusCode )
        {
            var memStream = new MemoryStream();
            var sw = new StreamWriter( memStream );
            sw.Write( content );
            sw.Flush();
            memStream.Position = 0;
            var httpContent = new StreamContent( memStream );
            var response = new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                Content = httpContent
            };
            var messageHandler = new FakeHttpMessageHandler( response );
            return messageHandler;
        }
        public FakeHttpMessageHandler( HttpResponseMessage response )
        {
            _response = response;
        }
        protected override Task<HttpResponseMessage> SendAsync( HttpRequestMessage request, CancellationToken cancellationToken )
        {
            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult( _response );
            return tcs.Task;
        }
    }
