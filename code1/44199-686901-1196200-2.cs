    public class JSONAttribute : ActionFilterAttribute
    {
       ...
        public override void OnActionExecuted( ActionExecutedContext filterContext)
        {
            var result = new JsonResult();
            result.Data = ((ViewResult)filterContext.Result).Model;
            filterContext.Result = result;
        }
        ...
    }
    [JSON]public ActionResult Index()
    {
        ViewData.Model = "This is my output";
        return View();
    }
