    <system.webServer>
      <modules>
        <remove name="UrlRoutingModule" />
        <add name="UrlRoutingModule" 
             type="System.Web.Routing.UrlRoutingModule, 
                   System.Web.Routing, 
                   Version=3.5.0.0, 
                   Culture=neutral, 
                   PublicKeyToken=31BF3856AD364E35"/>
      </modules>
    </system.webServer>
