    public ActionResult UploadFile()
    {
       var list= db.Photos
                   .Select(x=>new ProfileImageVm { FileName=Path.Combine(x.Url,x.Extension) ,
                                                    CreatedTime = x.Timestamp })
                   .ToList();
       return View(list);
    }
