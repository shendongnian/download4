    public class FixedAsyncRenderActionInvoker : System.Web.Mvc.Async.AsyncControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        {
            var ad = base.FindAction(controllerContext, controllerDescriptor, actionName);
            if (ad == null)
            {
                //check if the controller is an instance of IRenderMvcController
                if (controllerContext.Controller is IRenderMvcController)
                {
                    return new ReflectedActionDescriptor(
                        controllerContext.Controller.GetType().GetMethods()
                            .First(x => x.Name == "Index" &&
                                        x.GetCustomAttributes(typeof(NonActionAttribute), false).Any() == false),
                        "Index",
                        controllerDescriptor);
                }
            }
            return ad;
        }
    }
