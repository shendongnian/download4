    public class MyApiController : ApiController {
        IHeaderService myservice;
        public MyApiController(IHeaderService headers) {
            myservice = headers;
        }
    
        public override void Post([FromBody]TestDTO model) {
    
            var testName = myService.GetOsType();
            // more code
    
        }
    
    }
