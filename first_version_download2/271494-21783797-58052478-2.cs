    // You need to set your own keys and screen name
    var oAuthConsumerKey = "superSecretKey";
    var oAuthConsumerSecret = "superSecretSecret";
    var oAuthUrl = "https://api.twitter.com/oauth2/token";
    var screenname = "aScreenName";
    
    // Do the Authenticate
    var authHeaderFormat = "Basic {0}";
    
    var authHeader = string.Format(authHeaderFormat,
        Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
        Uri.EscapeDataString((oAuthConsumerSecret)))
    ));
    
    var postBody = "grant_type=client_credentials";
    
    HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
    authRequest.Headers.Add("Authorization", authHeader);
    authRequest.Method = "POST";
    authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
    authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    
    using (Stream stream = authRequest.GetRequestStream())
    {
        byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
        stream.Write(content, 0, content.Length);
    }
    
    authRequest.Headers.Add("Accept-Encoding", "gzip");
    
    WebResponse authResponse = authRequest.GetResponse();
    // deserialize into an object
    TwitAuthenticateResponse twitAuthResponse;
    using (authResponse)
    {
        using (var reader = new StreamReader(authResponse.GetResponseStream())) {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var objectText = reader.ReadToEnd();
            twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
        }
    }
    
    // Do the timeline
    var timelineFormat = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&include_rts=1&exclude_replies=1&count=5";
    var timelineUrl = string.Format(timelineFormat, screenname);
    HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
    var timelineHeaderFormat = "{0} {1}";
    timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, twitAuthResponse.token_type, twitAuthResponse.access_token));
    timeLineRequest.Method = "Get";
    WebResponse timeLineResponse = timeLineRequest.GetResponse();
    var timeLineJson = string.Empty;
    using (timeLineResponse)
    {
        using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
        {
             timeLineJson = reader.ReadToEnd();
        }
    }
    
    
    public class TwitAuthenticateResponse {
        public string token_type { get; set; }
        public string access_token { get; set; }
    }
