        public async void Download(string _urlToBeDownloaded = GlobalConstants.DownloadLanguageConfigurationUrl, string _fileNameToBeStoredAs = GlobalConstants.DownloadLanguageConfigurationXmlFilename, string _zipFilePassword = GlobalConstants.DownloadZipsPassword)
        {
            if (GlobalVariables.IsWP7 && _urlToBeDownloaded.ToLower().Contains("dropbox"))
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_urlToBeDownloaded);
                HttpWebResponse webResponse = await webRequest.GetResponseAsync() as HttpWebResponse;
                for (int i = 0; i < webResponse.Headers.Count; ++i)
                {
                    if (webResponse.Headers.AllKeys[i].ToLower() == "location")
                    {
                        _urlToBeDownloaded = webResponse.Headers["location"] ;
                        break;
                    }
                }
            }
            urlToBeDownloaded = _urlToBeDownloaded ;
            fileNameToBeStoredAs = _fileNameToBeStoredAs;
            zipFilePassword = _zipFilePassword;
            System.Uri targetUri = new System.Uri(urlToBeDownloaded);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUri);
            request.BeginGetResponse(new AsyncCallback(WebRequestCallBack), request);
        }
