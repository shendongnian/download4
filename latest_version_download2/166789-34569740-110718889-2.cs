    [RoutPrefix("Captcha")]
    public class CaptchaController : ApiController
    {
    
        [Route("Post/{solution}/{answer}")]
        [HttpPost]
        public bool Post(string solution, string answer)
        {
            return _service.Post();
    
        }
    }
