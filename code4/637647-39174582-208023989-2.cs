    using Dasync.Collections;
    var bag = new ConcurrentBag<object>();
    await myCollection.ParallelForEachAsync(async item =>
    {
      // some pre stuff
      var response = await GetData(item);
      bag.Add(response);
      // some post stuff
    }, maxDegreeOfParallelism: 10);
    var count = bag.Count;
