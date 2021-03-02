	<?xml version="1.0"?>
	<configuration>
		<configSections>
		  <sectionGroup name="system.web.extensions" type="System.Web.Configuration.SystemWebExtensionsSectionGroup, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
			<sectionGroup name="scripting" type="System.Web.Configuration.ScriptingSectionGroup, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
			  <section name="scriptResourceHandler" type="System.Web.Configuration.ScriptingScriptResourceHandlerSection, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="false" allowDefinition="MachineToApplication"/>
			  <sectionGroup name="webServices" type="System.Web.Configuration.ScriptingWebServicesSectionGroup, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
				<section name="jsonSerialization" type="System.Web.Configuration.ScriptingJsonSerializationSection, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="false" allowDefinition="Everywhere" />
				<section name="profileService" type="System.Web.Configuration.ScriptingProfileServiceSection, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="false" allowDefinition="MachineToApplication" />
				<section name="authenticationService" type="System.Web.Configuration.ScriptingAuthenticationServiceSection, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="false" allowDefinition="MachineToApplication" />
			  </sectionGroup>
			</sectionGroup>
		  </sectionGroup>
		</configSections>
	  
		<appSettings/>
		<connectionStrings/>
	  
		<system.web>
		  <pages>
			<controls>
			  <add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			</controls>
		  </pages>
		  
			<!-- 
				Set compilation debug="true" to insert debugging 
				symbols into the compiled page. Because this 
				affects performance, set this value to true only 
				during development.
			-->
			<compilation debug="true">
					<assemblies>
					  <add assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/></assemblies>
			</compilation>
			<!--
				The <authentication> section enables configuration 
				of the security authentication mode used by 
				ASP.NET to identify an incoming user. 
			-->
			<authentication mode="Windows"/>
			<!--
				The <customErrors> section enables configuration 
				of what to do if/when an unhandled error occurs 
				during the execution of a request. Specifically, 
				it enables developers to configure html error pages 
				to be displayed in place of a error stack trace.
			<customErrors mode="RemoteOnly" defaultRedirect="GenericErrorPage.htm">
				<error statusCode="403" redirect="NoAccess.htm" />
				<error statusCode="404" redirect="FileNotFound.htm" />
			</customErrors>
			-->
		  <httpHandlers>
			<remove verb="*" path="*.asmx"/>
			<add verb="*" path="*.asmx" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			<add verb="*" path="*_AppService.axd" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			<add verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" validate="false"/>
		  </httpHandlers>
		  <httpModules>
			<add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
		  </httpModules>
		</system.web>
		  <system.web.extensions>
			<scripting>
			  <webServices>
			  
			  </webServices>
			</scripting>
		  </system.web.extensions>
		  <system.webServer>
			<validation validateIntegratedModeConfiguration="false"/>
			<modules>
			  <add name="ScriptModule" preCondition="integratedMode" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			</modules>
			<handlers>
			  <remove name="WebServiceHandlerFactory-Integrated" />
			  <add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode"
				   type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			  <add name="ScriptHandlerFactoryAppServices" verb="*" path="*_AppService.axd" preCondition="integratedMode"
				   type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
			  <add name="ScriptResource" preCondition="integratedMode" verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
			</handlers>
		  </system.webServer>
	  
	   
	  
	</configuration>
