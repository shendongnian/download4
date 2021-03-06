    using Microsoft.SharePoint;
    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("https://sharepoint.domain.com"))
            using (SPWeb web = site.OpenWeb())
            {
                SPList list = web.GetList($"{web.ServerRelativeUrl.TrimEnd('/')}/DocumentLibrary");
                SPListItemCollection items = list.GetItems(new SPQuery());
    
                foreach (SPListItem item in items)
                {
                    object checkedOutTo = item[SPBuiltInFieldId.CheckoutUser];
                    if (checkedOutTo == null)
                    {
                        // Latest version
                        Console.WriteLine($"{item.ID} | {item.Versions[0].VersionLabel}");
                    }
                    else
                    {
                        // Find latest published version
                        SPListItemVersion version = item.Versions
                            .Cast<SPListItemVersion>()
                            .Where(v => v.Level == SPFileLevel.Published)
                            .FirstOrDefault();
    
                        if (version != null)
                            Console.WriteLine($"{item.ID} | {version.VersionLabel} | {checkedOutTo}");
                        else
                            Console.WriteLine($"{item.ID} | No published version | {checkedOutTo}");
                    }
                }
            }
        }
    }
