    var result = new HttpResponseMessage(HttpStatusCode.OK);    
    String filePath = HostingEnvironment.MapPath("~/Images/123.jpg");
    FileStream fileStream = new FileStream(filePath, FileMode.Open);
    Image image = Image.FromStream(fileStream);
    MemoryStream memoryStream = new MemoryStream();
    image.Save(memoryStream, ImageFormat.Jpeg);
    var byteArrayContent = new ByteArrayContent(memoryStream.ToArray());
    byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
    result.Content = byteArrayContent;
    return result;
