    string sXPathT = "//span[contains(@class,'group-label')]";
    string sXPathO = "//span[contains(@class,'group-value')]";
    HtmlAgilityPack.HtmlDocument Doc = new HtmlDocument();
    Doc.LoadHtml(strTestHTML);
    var vOddL = Doc.DocumentNode.SelectNodes(sXPathT);
    var vOddP = Doc.DocumentNode.SelectNodes(sXPathO);
    string GroupLabelNewsPaper = vOddL.ElementAt(0).InnerText.Trim();
    string GroupLabelFish = vOddL.ElementAt(1).InnerText.Trim();
    string GroupValueNewspaper = vOddP.ElementAt(0).InnerText.Trim();
    string GroupValueFish = vOddP.ElementAt(1).InnerText.Trim();
    Console.WriteLine($"{GroupLabelNewsPaper}\t{GroupValueNewspaper}");
    Console.WriteLine($"{GroupLabelFish}\t{GroupValueFish}");
