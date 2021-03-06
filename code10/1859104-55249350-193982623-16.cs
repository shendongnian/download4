    public class WebApiApplication : System.Web.HttpApplication
    	{
            protected void Application_Start()
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<DebugActivityLogger>().AsImplementedInterfaces().InstancePerDependency();
                builder.Update(Conversation.Container);
    
                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
        }
