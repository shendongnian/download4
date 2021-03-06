    public static string RemoveAllImageNodes(string html)
        {
            try
            {
                HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (document.DocumentNode.InnerHtml.Contains("<img"))
                {
                    foreach (var eachNode in document.DocumentNode.SelectNodes("//img"))
                    {
                        eachNode.Remove();
                        //eachNode.Attributes.Remove("src"); //This only removes the src Attribute from <img> tag
                    }
                }
                html = document.DocumentNode.OuterHtml;
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
