    if (lcl_name != value) 
    {
        lcl_name = value;
        Foo_Method(GetPropName(x => x.Name));
    }
    ...
    string GetPropName(Expression<Func<NameOfYourClass, String>> exp)
    {
        return ((MemberExpression)exp.Body).Member.Name;
    }
