        public ActionResult Index()
        {
            HtmlHelper helper = new HtmlHelper(new ViewContext(ControllerContext, new WebFormView(ControllerContext, "Index"), new ViewDataDictionary(), new TempDataDictionary(), new System.IO.StringWriter()), new ViewPage());
            helper.RenderAction("Index2");//call your action
            return View();
        }
        public ActionResult Index2(/*your arg*/)
        {
            //your code
            return new EmptyResult();
        }
