    public IActionResult SendResponse()
    {
        Request.HttpContext.Response.Headers.Add("X-Total-Count", "20");
        return Ok();
    }    
