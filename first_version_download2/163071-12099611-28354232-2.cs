    WebClient wc = new WebClient();
    wc.Proxy = new WebProxy(ip,port);
    var page = wc.DownloadString(url);
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(page);
