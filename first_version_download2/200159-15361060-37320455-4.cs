    public class ProcessRequestAsyncHandler ; IHttpAsyncHandler 
    {
       private  ProcessRequestDelegate asyncDelegate;
    
       public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            asyncDelegate = new ProcessRequestDelegate(ProcessRequest);
            return asyncDelegate.BeginInvoke(context, cb, extraData);
        }
    
        public void EndProcessRequest(IAsyncResult result)
        {
            asyncDelegate.EndInvoke(result);
        }
        private void ProcessRequest(HttpContext context)
        {
            // Do something long-running
        }
    }
