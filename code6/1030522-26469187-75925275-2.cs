    public ActionResult Index()
    { 
        List<PageNode> pageArray = new List<PageNode>();
        //// Use Sitefinity API get all pages
        IQueryable<PageNode> pageNodes = App.WorkWith().Pages().Where(pN => (pN.Page != null && pN.Page.Status == ContentLifecycleStatus.Live)).Get();
        foreach (var page in pageNodes) 
           pageArray.Add(page);
        return Json(pageArray, JsonRequestBehavior.AllowGet);
    }
