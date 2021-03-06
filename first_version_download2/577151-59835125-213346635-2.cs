cs
connection = new HubConnectionBuilder()
.WithUrl("http://localhost:5000/MiniLyokoHub", (opts) =>
{
    opts.HttpMessageHandlerFactory = (message) =>
    {
        if (message is HttpClientHandler clientHandler)
            // bypass SSL certificate
            clientHandler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => { return true; };
        return message;
    };
})
.Build();
