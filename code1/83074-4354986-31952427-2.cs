    <?xml version="1.0" encoding="utf-8"?>
    <!-- 
        Note: As an alternative to hand editing this file you can use the 
        web admin tool to configure settings for your application. Use
        the Website->Asp.Net Configuration option in Visual Studio.
        A full list of settings and comments can be found in 
        machine.config.comments usually located in 
        \Windows\Microsoft.Net\Framework\v2.x\Config 
    -->
    <configuration>
      <configSections>
        <sectionGroup name="elmah">
         </sectionGroup>
        <section name="dotNetOpenAuth" type="DotNetOpenAuth.Configuration.DotNetOpenAuthSection" requirePermission="false" allowLocation="true" />
      </configSections>
      <connectionStrings configSource="connectionStrings.config">
      </connectionStrings>
      <dotNetOpenAuth>
        <openid>
          <relyingParty>
            <behaviors>
              <add type="DotNetOpenAuth.OpenId.Behaviors.AXFetchAsSregTransform, DotNetOpenAuth" />
            </behaviors>
          </relyingParty>
        </openid>
      </dotNetOpenAuth>
      <system.web>
        <!-- 
                Set compilation debug="true" to insert debugging 
                symbols into the compiled page. Because this 
                affects performance, set this value to true only 
                during development.
        -->
        <compilation debug="true" targetFramework="4.0">
          <assemblies>
            <add assembly="System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL" />
            <add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <add assembly="System.Data.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
            <add assembly="System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
          </assemblies>
        </compilation>
        <!--
                The <authentication> section enables configuration 
                of the security authentication mode used by 
                ASP.NET to identify an incoming user. 
        -->
        <authentication mode="Forms">
          <forms loginUrl="~/Account/Logon" />
        </authentication>
        <membership>
          <providers>
            <clear />
            <add name="AspNetSqlMembershipProvider" type="System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ApplicationServices" enablePasswordRetrieval="false" enablePasswordReset="true" requiresQuestionAndAnswer="false" requiresUniqueEmail="false" passwordFormat="Hashed" maxInvalidPasswordAttempts="5" minRequiredPasswordLength="6" minRequiredNonalphanumericCharacters="0" passwordAttemptWindow="10" passwordStrengthRegularExpression="" applicationName="/" />
          </providers>
        </membership>
        <profile>
          <providers>
            <clear />
            <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ApplicationServices" applicationName="/" />
          </providers>
        </profile>
        <roleManager enabled="false">
          <providers>
            <clear />
            <add connectionStringName="ApplicationServices" applicationName="/" name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            <add applicationName="/" name="AspNetWindowsTokenRoleProvider" type="System.Web.Security.WindowsTokenRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
          </providers>
        </roleManager>
        <customErrors mode="RemoteOnly" defaultRedirect="/Dinners/Trouble">
          <error statusCode="404" redirect="/Dinners/Confused" />
        </customErrors>
    
        <pages controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" />
            <add namespace="System.Globalization" />
            <add namespace="System.Linq" />
            <add namespace="System.Collections.Generic" />
          </namespaces>
        </pages>
        <httpHandlers>
          <add verb="*" path="*.mvc" validate="false" type="System.Web.Mvc.MvcHttpHandler, System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL" />
        </httpHandlers>
        <httpModules>
        </httpModules>
        <trace enabled="true" requestLimit="10" pageOutput="false" traceMode="SortByTime" localOnly="true" />
      </system.web>
      <!-- 
            The system.webServer section is required for running ASP.NET AJAX under Internet
            Information Services 7.0.  It is not necessary for previous version of IIS.
      -->
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false" />
        <modules runAllManagedModulesForAllRequests="true">
        </modules>
        <handlers>
          <remove name="MvcHttpHandler" />
          <remove name="UrlRoutingHandler" />
          <add name="MvcHttpHandler" preCondition="integratedMode" verb="*" path="*.mvc" type="System.Web.Mvc.MvcHttpHandler, System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL" />
        </handlers>
      </system.webServer>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
            <bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
      <appSettings>
        <add key="microsoft.visualstudio.teamsystems.backupinfo" value="8;web.config.backup" />
        <!-- Fill in your various consumer keys and secrets here to make the sample work. -->
        <!-- You must get these values by signing up with each individual service provider. -->
        <!-- Twitter sign-up: https://twitter.com/oauth_clients -->
        <add key="twitterConsumerKey" value="" />
        <add key="twitterConsumerSecret" value="" />
      </appSettings>
      <system.serviceModel>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />
      </system.serviceModel>
    </configuration>
