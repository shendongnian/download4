    [RoutePrefix("api/foo")]
    public class FooController
    {
        public IHttpActionResult Bar(FooDTO foo)
        {
            // notify all connected clients
            GolbalHost.ConnectionManager.GetHubContext<FooHub>().Clients.All.newPayment(foo);
    
            return Ok(foo);
        }
    }
