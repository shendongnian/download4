    IEnumerable<IGrouping<int, EbrRecord>> query = ...
      orderby Location, RepName, AccountID
      select new EbrRecord(
        AccountID = EbrData[0],
        AccountName = EbrData[1],
        MBSegment = EbrData[2],
        RepName = EbrData[4],
        Location = EbrData[7],
        TsrLocation = EbrData[8]) into x
      group x by new {Location = x.Location, RepName = x.RepName} into g
      from g2 in g.Select((data, index) => new Record = data, Index = index })
                  .GroupBy(y => y.Index/100, y => y.Record)
      select g2;
    List<List<EbrRecord>> result = query.Select(g => g.ToList()).ToList();
