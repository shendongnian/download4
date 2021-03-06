    testdict
      .GroupBy(x => new { x.Value.Item2, x.Value.Item3 })
      .Select((x, i) => new {
        i,
        ShortCode = x.Key.Item1,
        ProductName = x.Key.Item2,
        Count = x.Count(),
      })
      .ToDictionary(x => x.i, x => new Tuple<string, string, int>(x.ShortCode, x.ProductName, x.Count));
