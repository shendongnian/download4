    var result = MyObjects.Select(x => new
    {
        ID = x.ID,
        CrewCodes = x.CrewCodes
    })
    .ToList()//enumerate the queryable
    .Select(x => new
    {
        ID = x.ID,
        String = string.Join(",",x.CrewCodes)
    });
