    public class MvcApplication : System.Web.HttpApplication
    {    
        protected void Application_Start()
        {
            /* code that bootstraps your container */
    
            //Set the controller builder to use our custom controller factory
            var controllerFactory = new YourControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
