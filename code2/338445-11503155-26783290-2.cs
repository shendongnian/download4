            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            System.IO.Stream responseStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
            string srcString = reader.ReadToEnd();
            // get the page ViewState                
            string viewStateFlag = "id=\"__VIEWSTATE\" value=\"";
            int i = srcString.IndexOf(viewStateFlag) + viewStateFlag.Length;
            int j = srcString.IndexOf("\"", i);
            string viewState = srcString.Substring(i, j - i);
            // get page EventValidation                
            string eventValidationFlag = "id=\"__EVENTVALIDATION\" value=\"";
            i = srcString.IndexOf(eventValidationFlag) + eventValidationFlag.Length;
            j = srcString.IndexOf("\"", i);
            string eventValidation = srcString.Substring(i, j - i);
            string submitButton = "LoginButton";
            // UserName and Password
            string userName = "userid";
            string password = "password";
            // Convert the text into the url encoding string
            viewState = System.Web.HttpUtility.UrlEncode(viewState);
            eventValidation = System.Web.HttpUtility.UrlEncode(eventValidation);
            submitButton = System.Web.HttpUtility.UrlEncode(submitButton);
            // Concat the string data which will be submit
            string formatString =
                     "txtUserName={0}&txtPassword={1}&btnSignIn={2}&__VIEWSTATE={3}&__EVENTVALIDATION={4}";
            string postString =
                     string.Format(formatString, userName, password, submitButton, viewState, eventValidation);
            // Convert the submit string data into the byte array
            byte[] postData = Encoding.ASCII.GetBytes(postString);
            // Set the request parameters
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Referer = url;
            request.KeepAlive = false;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; CIBA)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = myCookieContainer;
            System.Net.Cookie ck = new System.Net.Cookie("TestCookie1", "Value of test cookie");
            ck.Domain = request.RequestUri.Host;
            request.CookieContainer.Add(ck);
            request.CookieContainer.Add(response.Cookies);
            request.ContentLength = postData.Length;
            // Submit the request data
            System.IO.Stream outputStream = request.GetRequestStream();
            request.AllowAutoRedirect = true;
            outputStream.Write(postData, 0, postData.Length);
            outputStream.Close();
            
            // Get the return data
            response = request.GetResponse() as HttpWebResponse;
            responseStream = response.GetResponseStream();
            reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
            srcString = reader.ReadToEnd();
            Response.Write(srcString);
            Response.End();
