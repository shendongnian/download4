    HttpPostedFileBase file = Request.Files.Get(0);
    var allowedExtensions = new string[]{".jpeg", ".png"};
    string extension = Path.GetExtension(file.FileName);
    if(allowedExensions.Contains(extension)
    {
    //file allowed
    }
    else
    {
    //invalid extension
    }
