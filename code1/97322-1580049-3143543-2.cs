    protected override void Render(HtmlTextWriter writer)
    {
       StringBuilder htmlString = new StringBuilder(); // this will hold the string
       StringWriter stringWriter = new StringWriter(htmlString);
       HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
       Page.Render(tmpWriter);
       tmpWriter.Flush();
       
       writer.Write(DoReplaceLogic(htmlString.ToString()););
    }
