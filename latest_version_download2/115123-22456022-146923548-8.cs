    public void CallOtherMethodExpr(Expression<Action> expr)
    {
        string methodName;
        if (expr.Body.NodeType == ExpressionType.Call)
        {
            var call = expr.Body as MethodCallExpression;
            methodName = call.Method.Name;
        }
        else
            throw new InvalidOperationException("Expression must contain a method call");
        Console.WriteLine(methodName);
    }
