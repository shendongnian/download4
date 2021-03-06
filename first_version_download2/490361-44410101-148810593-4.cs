    public Expression<Func<TObj, bool>> BuildExpression<TObj, TVal>(TVal val)
    {
        var parameter = Expression.Parameter(typeof(TObj), "o");
        var valExpression = Expression.Constant(val, typeof(TVal));
        var body = Expression.Constant(false, typeof(bool));
        var properties = typeof(TObj).GetProperties();
        foreach (var property in properties)
        {
            var propertyExpression = Expression.Property(parameter, property);
            var equalExpression = Expression.Equal(propertyExpression, valExpression);
            body = Expression.Or(result, equalExpression);
        }
        return Expression.Lambda<Func<TObj, bool>>(body, parameter);
    }
    . . .
    using (var dbContext = new DbContext())
    {
        var whereExpression = BuildExpression<User, string>("foo");
        var contaningsFoo = dbContext.Users.Where(whereExpression);
    }
