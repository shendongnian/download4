    public static bool DeleteFileOnServer(Uri serverUri)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        FtpWebResponse response = (FtpWebResponse) request.GetResponse();
        Console.WriteLine("Delete status: {0}",response.StatusDescription);  
        response.Close();
        return true;
    }
