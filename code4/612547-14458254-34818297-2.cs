    var myHTMLString = "<html><body><h1>Hello!</h1></body></html>";
    
    // Convert your html string into a byte array
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(myHTMLString);
    
    // Create a MemoryStream from the byte array
    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
    
    // Assign the new MemoryStream to the web browser
    myWebBrowser.DocumentStream = ms;
