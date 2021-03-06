    var user = AllUsers.Current;
    var physicalResults = rows.Select(r => new SearchResult(r))
        .Where(t => t.BookType == "Physical")
        .Where(e => e.CanViewPhysical(e.PhysicalBookResult, user) );
    var digitalResults = rows.Select(r => new SearchResult(r))
        .Where(t => t.BookType == "Digital")
        .Where(e => e.CanViewDigital(e.DigitalBookResult, user) );
    // have somewhere
    var results = physicalResults.Concat(digitalResults).ToList();
