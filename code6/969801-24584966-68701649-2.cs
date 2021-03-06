     public class ChangePasswordAttribute : ActionFilterAttribute
     {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                //Check user has changed password or not 
                 if(--yes--){ nothing to do }
                 else{ GoToChangePasswordPage(filterContext); }
                 return;
        }
        private static void GoToChangePasswordPage(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary 
                { 
                    { "controller", "Login" }, 
                    { "action", "ChangePassword" } 
                });
        }
     }
