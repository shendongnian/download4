    // clear authentication cookie
    HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
    cookie1.Expires = DateTime.Now.AddYears(-1);
    Response.Cookies.Add(cookie1);
    HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
    cookie2.Expires = DateTime.Now.AddYears(-1);
    Response.Cookies.Add(cookie2);
