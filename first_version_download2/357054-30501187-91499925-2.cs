    public override Task<IHttpActionResult> Delete(int id)
    {
        return Task.FromResult(
                    ResponseMessage(Request.CreateResponse(
                                            HttpStatusCode.MethodNotAllowed,
                                            new NotSupportedException())));
    }
