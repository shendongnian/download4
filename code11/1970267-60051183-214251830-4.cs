      public static class ExpressionTreeHelper
    {
        /// <summary> Returns an IEnumerable of anonymous type defined by <paramref name="properties"/>. </summary>
        public static IEnumerable<dynamic> SelectDynamic<T>(this IEnumerable<T> source, params string[] properties)
        {
            return SelectProperties<T>(source.AsQueryable(), properties).Cast<dynamic>();
        }
        private static IQueryable SelectProperties<T>(this IQueryable<T> queryable, IEnumerable<string> propertyNames)
        {
            // get propertyinfo's from original type
            var properties = typeof(T).GetProperties().Where(p => propertyNames.Contains(p.Name));
            // Create the x => expression
            var lambdaParameterExpression = Expression.Parameter(typeof(T));
            // Create the x.<propertyName>'s
            var propertyExpressions = properties.Select(p => Expression.Property(lambdaParameterExpression, p));
            // Creating anonymous type using dictionary of property name and property type
            var anonymousType = AnonymousTypeUtils.CreateType(properties.ToDictionary(p => p.Name, p => p.PropertyType));
            var anonymousTypeConstructor = anonymousType.GetConstructors().Single();
            var anonymousTypeMembers = anonymousType.GetProperties().Cast<MemberInfo>().ToArray();
            // Create the new {} expression using 
            var anonymousTypeNewExpression = Expression.New(anonymousTypeConstructor, propertyExpressions, anonymousTypeMembers);
            var selectLambdaMethod = GetExpressionLambdaMethod(lambdaParameterExpression.Type, anonymousType);
            var selectBodyLambdaParameters = new object[] { anonymousTypeNewExpression, new[] { lambdaParameterExpression } };
            var selectBodyLambdaExpression = (LambdaExpression)selectLambdaMethod.Invoke(null, selectBodyLambdaParameters);
            var selectMethod = GetQueryableSelectMethod(typeof(T), anonymousType);
            var selectedQueryable = selectMethod.Invoke(null, new object[] { queryable, selectBodyLambdaExpression }) as IQueryable;
            return selectedQueryable;
        }
        
        private static MethodInfo GetExpressionLambdaMethod(Type entityType, Type funcReturnType)
        { 
            var prototypeLambdaMethod = GetStaticMethod(() => Expression.Lambda<Func<object, object>>(default(Expression), default(IEnumerable<ParameterExpression>))); 
            var lambdaGenericMethodDefinition = prototypeLambdaMethod.GetGenericMethodDefinition(); 
            var funcType = typeof(Func<,>).MakeGenericType(entityType, funcReturnType); 
            var lambdaMethod = lambdaGenericMethodDefinition.MakeGenericMethod(funcType); 
            return lambdaMethod; 
        } 
        
        private static MethodInfo GetQueryableSelectMethod(Type entityType, Type returnType)
        { 
            var prototypeSelectMethod = GetStaticMethod(() => Queryable.Select(default(IQueryable<object>), default(Expression<Func<object, object>>))); 
            var selectGenericMethodDefinition = prototypeSelectMethod.GetGenericMethodDefinition();
            return selectGenericMethodDefinition.MakeGenericMethod(entityType, returnType);
        } 
        
        private static MethodInfo GetStaticMethod(Expression<Action> expression)
        { 
            var lambda = expression as LambdaExpression; 
            var methodCallExpression = lambda.Body as MethodCallExpression; 
            return methodCallExpression.Method; 
        } 
    }
