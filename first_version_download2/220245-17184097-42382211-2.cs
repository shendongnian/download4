    public class CookieAwareWebClient : WebClient
    {
      public CookieAwareWebClient(CookieContainer container)
      {
        CookieContainer = container;
      }
      public CookieAwareWebClient()
        : this(new CookieContainer())
      {
      }
      public CookieContainer CookieContainer { get; private set; }
    
      protected override WebRequest GetWebRequest(Uri address)
      {
        var request = (HttpWebRequest)base.GetWebRequest(address);
        request.CookieContainer = CookieContainer;
        return request;
      }
    }
