       public ActionResult GetPartial()
        {
          var viewStr=RenderPartialToString("ViewAddress",new object())
          return content(viewStr);
        }
        // by this method you can  get string of view
        public static string RenderPartialToString(string controlName, object viewData)
            {
                ViewPage viewPage = new ViewPage() { ViewContext = new ViewContext() };
            viewPage.ViewData = new ViewDataDictionary(viewData);
            viewPage.Controls.Add(viewPage.LoadControl(controlName));
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter tw = new HtmlTextWriter(sw))
                {
                    viewPage.RenderControl(tw);
                }
            }
            return sb.ToString();
        }
