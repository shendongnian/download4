    IEnumerable<MyDto> list = new List<MyDto>(); // This is the stuff you parsed
    var results = new Dictionary<Tuple<Guid, Guid>, MyDto>();
    foreach (var item in list) {
        var key = new Tuple<Guid, Guid>(item.SomeId1, item.SomeId2);
        if (results.ContainsKey(key))
            foreach (var entry in item.JsonDictionary)
                results[key].JsonDictionary[entry.Key] = entry.Value;
        else results[key] = item;
    }
    list = results.Values;
