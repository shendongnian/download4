    string postData = Console.ReadLine();
    
    using (WebCient wc = new WebClient())
    {
        wc.Headers.Add("Content-Type","application/x-www-form-urlencoded");
        // Upload the input string using the HTTP 1.0 POST method.
        byte[] byteArray = Encoding.ASCII.GetBytes(postData);
        byte[] byteResult= wc.UploadData("http://targetwebiste","POST",byteArray);
        // Decode and display the result.
        Console.WriteLine("\nResult received was {0}",
                               Encoding.ASCII.GetString(byteResult));
    }
