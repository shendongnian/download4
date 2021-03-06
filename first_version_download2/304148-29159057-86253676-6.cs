    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        SetupIocContainer();
        Forms.Init();
        FormsMaps.Init();
        window = new UIWindow(UIScreen.MainScreen.Bounds);
        window.RootViewController = App.GetMainPage().CreateViewController();
        window.MakeKeyAndVisible();
        return true;
    }
    
    private void SetupIocContainer()
    {
        var resolverContainer = new SimpleContainer();
        var app = new XFormsAppiOS();
        app.Init(this);
    
        resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
            .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
            .Register<IHudService>(t => t.Resolve<IHudService>())
            .Register<IXFormsApp>(app)
            .Register<IDependencyContainer>(t => resolverContainer);
    
        Resolver.SetResolver(resolverContainer.GetResolver());
    }
