    Session.Clear();
    Session.Abandon();
    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
    
