			<add path="ChartImage.axd" type="Telerik.Web.UI.ChartHttpHandler" verb="*" validate="false" />
			<add path="Telerik.Web.UI.SpellCheckHandler.axd" type="Telerik.Web.UI.SpellCheckHandler" verb="*" validate="false" />
			<add path="Telerik.Web.UI.DialogHandler.aspx" type="Telerik.Web.UI.DialogHandler" verb="*" validate="false" />
			<add path="Telerik.RadUploadProgressHandler.ashx" type="Telerik.Web.UI.RadUploadProgressHandler" verb="*" validate="false" />
			<add path="Telerik.Web.UI.WebResource.axd" type="Telerik.Web.UI.WebResource" verb="*" validate="false" />
		</httpHandlers>
		<httpModules>
		<!-- Only needed if RadUpload is used in the site -->
		<!--	<add name="RadUploadModule" type="Telerik.Web.UI.RadUploadHttpModule" /> -->
		<!-- Only needed if RadCompression is used in the site -->
		<!--	<add name="RadCompression" type="Telerik.Web.UI.RadCompression" />  -->
		</httpModules>
	</system.web>
	<system.webServer>
		<validation validateIntegratedModeConfiguration="false" />
		<modules runAllManagedModulesForAllRequests="true">
		<!-- Only needed if RadUpload is used in the site -->
		<!--	<remove name="RadUploadModule" /> -->
		<!--	<add name="RadUploadModule" type="Telerik.Web.UI.RadUploadHttpModule" preCondition="integratedMode" /> -->
		<!-- Only needed if RadCompression is used in the site -->
		<!--	<remove name="RadCompression" /> -->
		<!--	<add name="RadCompression" type="Telerik.Web.UI.RadCompression" preCondition="integratedMode" /> -->
		</modules>
		<handlers>
			<remove name="ChartImage_axd" />
			<add name="ChartImage_axd" path="ChartImage.axd" type="Telerik.Web.UI.ChartHttpHandler" verb="*" preCondition="integratedMode" />
			<remove name="Telerik_Web_UI_SpellCheckHandler_axd" />
			<add name="Telerik_Web_UI_SpellCheckHandler_axd" path="Telerik.Web.UI.SpellCheckHandler.axd" type="Telerik.Web.UI.SpellCheckHandler" verb="*" preCondition="integratedMode" />
			<remove name="Telerik_Web_UI_DialogHandler_aspx" />
			<add name="Telerik_Web_UI_DialogHandler_aspx" path="Telerik.Web.UI.DialogHandler.aspx" type="Telerik.Web.UI.DialogHandler" verb="*" preCondition="integratedMode" />
			<remove name="Telerik_RadUploadProgressHandler_ashx" />
			<add name="Telerik_RadUploadProgressHandler_ashx" path="Telerik.RadUploadProgressHandler.ashx" type="Telerik.Web.UI.RadUploadProgressHandler" verb="*" preCondition="integratedMode" />
			<remove name="Telerik_Web_UI_WebResource_axd" />
			<add name="Telerik_Web_UI_WebResource_axd" path="Telerik.Web.UI.WebResource.axd" type="Telerik.Web.UI.WebResource" verb="*" preCondition="integratedMode" />
		</handlers>
	</system.webServer>
