    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace q6010555
    {
        class Demo
        {
            public delegate int DemoDelegate();
    
            private static int One()
            {
                return 1;
            }
            private static void CallDelegate(Expression<Func<DemoDelegate>> expr)
            {
                var lambda = expr as LambdaExpression;
                var body = lambda.Body;
                var field = body as MemberExpression;
                var name = field.Member.Name;
                var constant = field.Expression as ConstantExpression;
                var value = (DemoDelegate)((field.Member as FieldInfo).GetValue(constant.Value));
    
                // now you have the variable name... you may use it somehow:
    
                value();
            }
            static void Main(string[] args)
            {
                DemoDelegate one = Demo.One;
                CallDelegate(() => one);
            }
        }
    }
