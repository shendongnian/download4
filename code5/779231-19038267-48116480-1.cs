    int?[] ranges = new int?[] { 1500, 2500, 4000 };
    var groups = from p in people
                 group p by ranges.FirstOrDefault(r => r > p.Value) into g
                 where g.Key != null
                 select new {
                     People = g,
                     To = g.Key,
                     From = ranges.Where(r => r < g.Key)
                                  .Select(r => r + 1).DefaultIfEmpty(0).Last()
                 };
