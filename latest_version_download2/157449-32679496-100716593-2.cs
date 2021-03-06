        public ApiServices Services { get; set; }
    
        [AuthorizeLevel(AuthorizationLevel.User)]
        public async Task<JObject> GetUserInfo()
        {
            //Get the current logged in user
            ServiceUser user = this.User as ServiceUser;
            if (user == null)
            {
                throw new InvalidOperationException("This can only be called by authenticated clients");
            }
    
            //Get Identity Information for the current logged in user
            var identities = await user.GetIdentitiesAsync();
            var result = new JObject();
    
            //Check if the user has logged in using Facebook as Identity provider
            var fb = identities.OfType<FacebookCredentials>().FirstOrDefault();
            if (fb != null)
            {
                var accessToken = fb.AccessToken;
                result.Add("facebook", await GetProviderInfo("https://graph.facebook.com/me?access_token=" + accessToken));
            }
    
            //Check if the user has logged in using Microsoft Identity provider
            var ms = identities.OfType<MicrosoftAccountCredentials>().FirstOrDefault();
            if (ms != null)
            {
                var accessToken = ms.AccessToken;
                result.Add("microsoft", await GetProviderInfo("https://apis.live.net/v5.0/me/?method=GET&access_token=" + accessToken));
            }
    
            //Check if the user has logged in using Google as Identity provider
            var google = identities.OfType<GoogleCredentials>().FirstOrDefault();
            if (google != null)
            {
                var accessToken = google.AccessToken;
                result.Add("google", await GetProviderInfo("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessToken));
            }
    
            return result;
        }
    
        private async Task<JToken> GetProviderInfo(string url)
        {
            var c = new HttpClient();
            var resp = await c.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            return JToken.Parse(await resp.Content.ReadAsStringAsync());
        }
    }
