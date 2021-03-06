    string formParams = string.Format("j_username={0}&j_password={1}", userName, userPass);
    string cookieHeader;
    var cookies = new CookieContainer(); // added this line
    WebRequest request = WebRequest.Create(_signInPage);
    request.CookieContainer = cookies; // added this line
    request.ContentType = "text/plain";
    request.Method = "POST";
    byte[] bytes = Encoding.ASCII.GetBytes(formParams);
    request.ContentLength = bytes.Length;
    using (Stream os = request.GetRequestStream())
    {
       os.Write(bytes, 0, bytes.Length);
    }
    request.GetResponse(); // removed some code here, no need to read response manually
    WebRequest getRequest = WebRequest.Create(sessionHistoryPage);
    getRequest.CookieContainer = cookies; // added this line
    getRequest.Method = "GET";
    WebResponse getResponse = getRequest.GetResponse();
    try
    {
       using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
       {
          textBox1.AppendText(sr.ReadToEnd());
       }
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message);
       throw;
    }
