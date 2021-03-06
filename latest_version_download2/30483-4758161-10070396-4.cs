    foreach (var filter in filters)
    {
        var value = filter.Value.ToLower();  // for the lambdas
        switch (filter.Key)
        {
            case FilterType.Customer:
                jobQuery = jobQuery.Where(x => x.KUNDREF != null &&
                           x.KUNDREF.ToLower().Contains(value));
                break;
    
            case FilterType.Name:
                jobQuery = jobQuery.Where(x => x.JOBBESKR != null &&
                           x.JOBBESKR.ToLower().Contains(value));
                break;
        }
    }
