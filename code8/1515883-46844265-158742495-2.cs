    var multipartContent = await response.Content.ReadAsMultipartAsync();
    HttpResponseMessage workingResponse = null;
    foreach (HttpContent currentContent in multipartContent.Contents) {
    	// Two cases:
    	// 1. a "single" response
    	if (currentContent.Headers.ContentType.MediaType.Equals("application/http", StringComparison.OrdinalIgnoreCase) && !currentContent.Headers.ContentType.Parameters.Any(parameter => parameter.Name.Equals("msgtype", StringComparison.OrdinalIgnoreCase) && parameter.Value.Equals("response", StringComparison.OrdinalIgnoreCase))) {
    		currentContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("msgtype", "response"));
    		workingResponse = await currentContent.ReadAsHttpResponseMessageAsync();
    		// The workingResponse object contains a classic exploitable HttpResponseMessage (with IsSuccessStatusCode, Content.ReadAsStringAsync().Result, etc.)
    	}
    	// 2. a changeset response, which is an embedded multipart content
    	else {
    		var subMultipartContent = await currentContent.ReadAsMultipartAsync();
    		foreach (HttpContent currentSubContent in subMultipartContent.Contents) {
    			currentSubContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("msgtype", "response"));
    			workingResponse = await currentSubContent.ReadAsHttpResponseMessageAsync();
    			// Same here, the workingResponse object contains a classic exploitable HttpResponseMessage
    		}
    	}
    }
