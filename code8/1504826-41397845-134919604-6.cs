     public class CustomAreaViewEngine : VirtualPathProviderViewEngine
    {
        public CustomAreaViewEngine()
        {
            MasterLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.master",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.master",
            "~/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.master",
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.master",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/{2}/Views/{1}/{0}.master",
            "~/Areas/{2}/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/{2}/Views/Shared/{0}.master",
            "~/Areas/{2}/{2}/Views/Shared/{0}.cshtml",
            "~/{2}/Views/{1}/{0}.master",
            "~/{2}/Views/{1}/{0}.cshtml",
            "~/{2}/Views/Shared/{0}.master",
            "~/{2}/Views/Shared/{0}.cshtml",
            "~/{2}/{2}/Views/{1}/{0}.master",
            "~/{2}/{2}/Views/{1}/{0}.cshtml",
            "~/{2}/{2}/Views/Shared/{0}.master",
            "~/{2}/{2}/Views/Shared/{0}.cshtml",
            };
            ViewLocationFormats = new string[]
            {
            "~/Areas/{2}/Views/{1}/{0}.aspx",
            "~/Areas/{2}/Views/{1}/{0}.ascx",
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.aspx",
            "~/Areas/{2}/Views/Shared/{0}.ascx",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/{2}/Views/{1}/{0}.aspx",
            "~/Areas/{2}/{2}/Views/{1}/{0}.ascx",
            "~/Areas/{2}/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/{2}/Views/Shared/{0}.aspx",
            "~/Areas/{2}/{2}/Views/Shared/{0}.ascx",
            "~/Areas/{2}/{2}/Views/Shared/{0}.cshtml",
            "~/{2}/Views/{1}/{0}.aspx",
            "~/{2}/Views/{1}/{0}.ascx",
            "~/{2}/Views/{1}/{0}.cshtml",
            "~/{2}/Views/Shared/{0}.aspx",
            "~/{2}/Views/Shared/{0}.ascx",
            "~/{2}/Views/Shared/{0}.cshtml",
            "~/{2}/{2}/Views/{1}/{0}.aspx",
            "~/{2}/{2}/Views/{1}/{0}.ascx",
            "~/{2}/{2}/Views/{1}/{0}.cshtml",
            "~/{2}/{2}/Views/Shared/{0}.aspx",
            "~/{2}/{2}/Views/Shared/{0}.ascx",
            "~/{2}/{2}/Views/Shared/{0}.cshtml",
            "~/Views/{1}/{0}.aspx",
            "~/Views/{1}/{0}.ascx",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.aspx",
            "~/Views/Shared/{0}.ascx",
            "~/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = ViewLocationFormats;
        }
