    public static Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderByFunc<T>(
        this Tuple<IEnumerable<string>, SortingType> sortCriteria)
    {
        var selector = GetSelector<T>(sortCriteria.Item1);
        Type[] argumentTypes = new[] { typeof(T), selector.Item2 };
        var orderByMethod = typeof(Queryable).GetMethods()
            .First(method => method.Name == "OrderBy"
                && method.GetParameters().Count() == 2)
                .MakeGenericMethod(argumentTypes);
        var orderByDescMethod = typeof(Queryable).GetMethods()
            .First(method => method.Name == "OrderByDescending"
                && method.GetParameters().Count() == 2)
                .MakeGenericMethod(argumentTypes);
        if (sortCriteria.Item2 == SortingType.Descending)
            return query => (IOrderedQueryable<T>)
                orderByDescMethod.Invoke(null, new object[] { query, selector.Item1 });
        else
            return query => (IOrderedQueryable<T>)
                orderByMethod.Invoke(null, new object[] { query, selector.Item1 });
    }
