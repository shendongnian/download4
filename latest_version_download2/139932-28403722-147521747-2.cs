    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
    
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    
            JavaScriptSerializer serializer = new JavaScriptSerializer();
    
            CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
    
            CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
            newUser.Id = serializeModel.Id;
            newUser.FirstName = serializeModel.FirstName;
            newUser.LastName = serializeModel.LastName;
    
            HttpContext.Current.User = newUser;
        }
    }
