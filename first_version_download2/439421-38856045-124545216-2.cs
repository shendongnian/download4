      public class LoginFilter : ActionFilterAttribute
      {
        public override void OnActionExecuting(ActionExecutingContextfilterContext)
        {    
            // Authenticate (somehow) and retrieve the ID
            int idValue = Authentication.SomeMethod();
        
        // Pass the ID through to the controller?
      filterContext.Controller.ViewData.Add("Id", idValue);
    }
