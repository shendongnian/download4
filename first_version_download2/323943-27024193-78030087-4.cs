    var sortedCardResourceSet.Cast<DictionaryEntry>().OrderBy(de => de.Value).ToList();
    foreach (var entry in sortedCardResourceSet)
    {
        ...
    }
    ...
