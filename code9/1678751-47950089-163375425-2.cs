    [RoutePrefix("doom-place")]
    public class DoomPlaceController : Conroller {
        //Matches GET /doom-place
        //Matches GET /doom-place/some_parameter
        [HttpGet]
        [Route("{parameter?}")]
        public ActionResult Index(string parameter) { 
            return View(); 
        }
    }
