    public class TestTagHelper : AnchorTagHelper
    {
        public TestTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator) { }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
		    //do custom processing
		    output.Attributes.SetAttribute("class", "custom-class");
            //let the base class generate the href 
            base.ProcessAsync(context, output);
        }
    }
