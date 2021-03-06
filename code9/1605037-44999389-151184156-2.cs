    public class RedirectAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect);
                response.Headers.Location = new Uri("https://www.stackoverflow.com");
                actionContext.Response = response;
            }
        }
