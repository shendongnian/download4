    protected void Application_Start()
    {
    	AreaRegistration.RegisterAllAreas();
    	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    	RouteConfig.RegisterRoutes(RouteTable.Routes);
    	BundleConfig.RegisterBundles(BundleTable.Bundles);
    
    	var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
    
    	var newLocationPath = new string[]
    	{
    		"~/Views/Home/Index.cshtml",
            "~/Views/Home/Index.vbhtml",
            "~/Views/Common/{0}.cshtml",
            "~/Views/Common/{0}.vbhtml"
    	}.Concat(razorEngine.ViewLocationFormats);
    
    	razorEngine.ViewLocationFormats = newLocationPath.ToArray();
    }
