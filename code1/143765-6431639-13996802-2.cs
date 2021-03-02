    public class MyAuthorizeAttribute : AuthorizeAttribute {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpStatusCodeResult(403);
            else
                filterContext.Result = new HttpUnauthorizedResult();
        } 
    }
    <configuration>
      <system.webServer>
        <httpErrors errorMode="Custom" existingResponse="Replace">
          <remove statusCode="403" />
          <error statusCode="403" responseMode="ExecuteURL" path="/Error/MyCustom403page" />
        </httpErrors>
      </system.webServer>
    </configuration>
