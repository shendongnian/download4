    [OperationContract]
    [WebInvoke(UriTemplate = "uploadImage/{parameter1}/{parameter2}")]
    void uploadImage(Stream fileStream, string fileName);
.
    public void uploadImage(Stream fileStream, string fileName)
        {
            string filePath = @"C:\ImageUpload\";
            using (FileStream filetoUpload = new FileStream(filePath + fileName, FileMode.Create))
            {
                byte[] byteArray = new byte[10000];
                int bytesRead = 0;
                do
                {
                    bytesRead = fileStream.Read(byteArray, 0, byteArray.Length);
                    if (bytesRead > 0)
                    {
                        filetoUpload.Write(byteArray, 0, bytesRead);
                    }
                }
                while (bytesRead > 0);
            }
        }
