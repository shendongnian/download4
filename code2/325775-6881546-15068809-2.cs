    WebRequest request;
    string text;
            string url = Request["UrlToGet"];
            request = (HttpWebRequest)
                WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
            }
