    public void CompareValue<TModel,TProperty>(TModel x, TModel y, Expression<Func<TModel, TProperty>> expression)
        where TModel : class
        where TProperty : IEquatable<TProperty>
    {
        Type modelType = typeof(TModel);
        PropertyInfo propInfo = modelType.GetProperty(((MemberExpression)expression.Body).Member.Name);
        
        TProperty xValue = (TProperty)propInfo.GetValue(x);
        TProperty yValue = (TProperty)propInfo.GetValue(y);
        if (xValue.Equals(yValue))
        {
            Console.WriteLine("Match!");
        }
    }
