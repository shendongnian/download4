    public class SampleActionFilterAttribute : TypeFilterAttribute
    {
        ... 
        public void OnActionExecuting(ActionExecutedContext context)
        {
            // read body before MVC action execution
            string bodyData = ReadBodyAsString(context.HttpContext.Request);
        }
        private string ReadBodyAsString(HttpRequest request)
        {
            var initialBody = request.Body; // Workaround
            try
            {
                request.EnableRewind();
                using (StreamReader reader = new StreamReader(request.Body))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
            finally
            {
                request.Body = initialBody; // Workaround
            }
            return string.Empty;
        }
     }
