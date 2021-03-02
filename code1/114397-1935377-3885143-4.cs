    var basicHttpBinding = new BasicHttpBinding();
    basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
    var endpoint = new EndpointAddress("http://example.com/myWindowsAuthN");
    var client = new MyBeanClient(basicHttpBinding, endpoint);
    client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
    client.ChannelFactory.Credentials.Windows.ClientCredential.Domain = "domain";
    client.ChannelFactory.Credentials.Windows.ClientCredential.UserName = "username";
    client.ChannelFactory.Credentials.Windows.ClientCredential.Password = "password";
