      //*
     Public void Application_BeginRequest(Object sender, EventArgs e) 
     {     
     // Code that runs on application startup                                                            
     HttpCookie cookie = HttpContext.Current.Request.Cookies["CultureInfo"];
     if (cookie != null && cookie.Value != null) 
     {
     System.Threading.Thread.CurrentThread.CurrentUICulture = new  
     System.Globalization.CultureInfo(cookie.Value);
     System.Threading.Thread.CurrentThread.CurrentCulture = new     
     System.Globalization.CultureInfo(cookie.Value);
     }
     else
     {
     System.Threading.Thread.CurrentThread.CurrentUICulture = new   
     System.Globalization.CultureInfo("tr-TR");
     System.Threading.Thread.CurrentThread.CurrentCulture = new   
     System.Globalization.CultureInfo("tr-TR");
     }
     }
     //*
       
    
