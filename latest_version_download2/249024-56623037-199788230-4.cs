    [Authorize(Policy = "Policy1")]
    public class HomeController : Controller
    {
        [Authorize(Policy = "Policy2")]
        public ActionResult MyAction()
        {
           ...
        }
        
        [Authorize(Policy = "Policy3")]
        public ActionResult MyAnotherAction()
        {
           ...
        }
        
        [AllowAnonymous]
        public ActionResult NotSecuredAtAll()
        {
           ...
        }
    }
