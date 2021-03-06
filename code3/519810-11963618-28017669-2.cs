        public static IQueryable<Investment> PerformanceSearch(Expression<Func<Performance, double>> searchColumn, double minValue, double maxValue) {
                                     
            // LINQ Expression that represents the column passed in searchColumn
            // x.Return1Month
            MemberExpression columnExpression = searchColumn.Body as MemberExpression;
            // LINQ Expression to represent the parameter of the lambda you pass in
            // x
            ParameterExpression parameterExpression = (ParameterExpression)columnExpression.Expression;
            // Expressions to represent min and max values
            Expression minValueExpression = Expression.Constant(minValue);
            Expression maxValueExpression = Expression.Constant(maxValue);
            // Expressions to represent the boolean operators
            // x.Return1Month >= minValue
            Expression minComparisonExpression = Expression.GreaterThanOrEqual(columnExpression, minValueExpression);
            // x.Return1Month <= maxValue
            Expression maxComparisonExpression = Expression.LessThanOrEqual(columnExpression, maxValueExpression);
            // (x.Return1Month >= minValue) && (x.Return1Month <= maxValue)
            Expression filterExpression = Expression.AndAlso(minComparisonExpression, maxComparisonExpression);
            // x => (x.Return1Month >= minValue) && (x.Return1Month <= maxValue)
            Expression<Func<Performance, bool>> filterLambdaExpression = Expression.Lambda<Func<Performance, bool>>(filterExpression, parameterExpression);
            // use the completed expression to filter your collection
            // This requires that your collection is an IQueryable.
            // I believe that EF tables are already IQueryable, so you can probably
            // drop the .AsQueryable calls and it will still work fine.
            var query = (from i in _investments
                         join p in _performance.AsQueryable().Where(filterLambdaExpression)
                           on i.InvestmentId equals p.InvestmentId
                         select i);
            return query.AsQueryable();
        } 
