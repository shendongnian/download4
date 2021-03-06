    // usage - set up report
    var report = new Report {
        Header =
        {
            Name = "My new report", 
            Date = DateTime.UtcNow
        }};
    // add lineitems to body
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 1,
            ItemPrice = 2.30f,
            PartDescription = "New shoes", 
            PartNumber = "SHOE123"
        });
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 2, 
            ItemPrice = 12.00f, 
            PartDescription = "Old shoes", 
            PartNumber = "SHOE999"
        });
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 3, 
            ItemPrice = 0.25f, 
            PartDescription = "Classic Sox", 
            PartNumber = "SOX567"
        });
    // calculate the TotalPrice per lineitem
    foreach (var item in report.Body.LineItems)
    {
        item.TotalPrice = item.ItemPrice*item.ItemNumber;
    }
    // summerize the lineitems values in the footer
    report.Footer.TotalItems = report.Body.LineItems.Count();
    report.Footer.TotalPrice = report.Body.LineItems.Sum(x => x.ItemPrice);
