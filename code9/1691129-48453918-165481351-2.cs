    HttpCookie appCookie = new HttpCookie("AppCookie");
    appCookie.Value = "written " + DateTime.Now.ToString();
    appCookie.Expires = DateTime.Now.AddDays(1);
    appCookie.Path = "/Application1"; //this can be remove
    Response.Cookies.Add(appCookie);
