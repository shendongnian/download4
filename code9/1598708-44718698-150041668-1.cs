        var categoryGroups = products
            .SelectMany(x => x.CategoryGroups)
            .GroupBy(x.CategoryGroupId)
            .Select(x => new CategoryGroup
                         {
                             Categories = x.Values.SelectMany(y => y.Categories).Distinct(y => y.CategoryId).ToList(),
                             CategoryGroupId = x.CategoryGroupId,
                             Name = x.Name
                         }).ToList();
