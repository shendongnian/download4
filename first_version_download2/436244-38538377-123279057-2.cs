    using System.Linq.Expressions;
    
    class FieldAccessor
    {
        private static readonly fieldParameter = Expression.Parameter(typeof(object));
        private static readonly ownerParameter = Expression.Parameter(typeof(object));
            
        public FieldAccessor(Type type, string fieldName)
        {
            var field = type.GetField(fieldName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field == null) throw new ArgumentException();
            
            var fieldExpression = Expression.Field(
                Expression.Convert(ownerParameter, type), field);
            Get = Expression.Lambda<Func<object, object>>(
                Expression.Convert(fieldExpression, typeof(object)),
                ownerParameter).Compile();
            Set = Expression.Lambda<Action<object, object>>(
                Expression.Assign(fieldExpression,
                    Expression.Convert(fieldParameter, field.FieldType)), 
                ownerParameter, fieldParameter).Compile();
        }
    
        public Func<object, object> Get { get; }
        
        public Action<object, object> Set { get; }
    }
