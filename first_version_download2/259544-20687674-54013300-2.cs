    <system.web.webPages.razor>
        <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" />
            <!-- THIS!! -->
            <add namespace="MyProject.My.Name.Space.For.Html.Extensions" /> 
          </namespaces>
        </pages>
     </system.web.webPages.razor>
