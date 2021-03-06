    public static IDictionary<string, string> MergePaths(
        IEnumerable<string> partialPaths, IEnumerable<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .ToList();
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            // Capture the index of each full path so we can skip full paths later.
            .Select((p, i) => new { p.Original, p.Reverse, Index = i })
            .ToList();
        var lastFullPathIndex = 0;
        return sortedPartialPaths.ToDictionary(
            pp => pp.Original,
            pp => 
            {
                var matchedFullPath = sortedFullPaths
                    // Skip all full paths that have already been matched.
                    .Skip(lastFullPathIndex)
                    // Skip all full paths that are smaller in terms of string sort order.
                    .SkipWhile(fp => fp.Reverse.CompareTo(pp.Reverse) < 0)
                    // Only take the full paths that end with the matching partial path. 
                    // Should only take one. If there are more the rest will be discarded.
                    .TakeWhile(fp => fp.Reverse.StartsWith(pp.Reverse))
                    .FirstOrDefault();
                // Update the index of our last match.
                lastFullPathIndex = matchedFullPath?.Index ?? lastFullPathIndex;
                return matchedFullPath?.Original;
            });
    }
	
