    public string UploadChatFile(Stream fileStream, string uri, string postData, string fileName)
            {
                string boundary = "----------------------------" +
                DateTime.Now.Ticks.ToString("x");
    
                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest2.ContentType = "multipart/form-data; boundary=" +
                boundary;
                httpWebRequest2.Method = "POST";
                httpWebRequest2.KeepAlive = true;
    
    
                Stream memStream = new System.IO.MemoryStream();
                byte[] boundarybytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
    
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
    
                string headerTemplate = string.Format("Content-Disposition: form-data; name=\"postdata\"\r\n{0}\r\n\r\n", postData);
    
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(headerTemplate);
    
                memStream.Write(headerbytes, 0, headerbytes.Length);
    
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
    
                headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";
    
                //string header = string.Format(headerTemplate, "file" + i, files[i]);
                string header = string.Format(headerTemplate, "uplTheFile", fileName);
    
                headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
    
                memStream.Write(headerbytes, 0, headerbytes.Length);
    
    
                //FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
    
                int bytesRead = 0;
    
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
    
                }
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                fileStream.Close();
    
                httpWebRequest2.ContentLength = memStream.Length;
                Stream requestStream = httpWebRequest2.GetRequestStream();
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
    
                WebResponse webResponse2 = httpWebRequest2.GetResponse();
    
                Stream stream2 = webResponse2.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
    
                string responseString = reader2.ReadToEnd();
    
                
                return responseString;
            }
        
    
