    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Reflection;
    using System.IO.Packaging;
    using System.Windows.Markup;
    namespace ClassLibrary1
    {
        static class Extension
        {
            public static void LoadViewFromUri(this UserControl userControl, string baseUri)
            {
                try
                {
                    var resourceLocater = new Uri(baseUri, UriKind.Relative);
                    var exprCa = (PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { resourceLocater });
                    var stream = exprCa.GetStream();
                    var uri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), resourceLocater);
                    var parserContext = new ParserContext
                    {
                        BaseUri = uri
                    };
                    typeof(XamlReader).GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { stream, parserContext, userControl, true });
                }
                catch (Exception)
                {
                    //log
                }
            }
        }
    }
