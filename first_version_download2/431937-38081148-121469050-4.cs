        public class AnyTagDefinition : ContentTagDefinition
        {
            private const string conditionParameter = "condition";
    
            public AnyTagDefinition()
                : base("Any")
            {}
    
            public override IEnumerable<TagParameter> GetChildContextParameters()
            {
                return new TagParameter[0];
            }
    
            public override bool ShouldGeneratePrimaryGroup(Dictionary<string, object> arguments)
            {
                object condition = arguments[conditionParameter];
                return isConditionSatisfied(condition);
            }
    
            protected override IEnumerable<TagParameter> GetParameters()
            {
                return new TagParameter[] { new TagParameter(conditionParameter) { IsRequired = true } };
            }
    
            protected override bool GetIsContextSensitive()
            {
                return false;
            }
    
            private bool isConditionSatisfied(object condition)
            {
                if (condition is IEnumerable)
                {
                    return (condition as IEnumerable).Cast<object>().Any();
                }
    
                return false;
            }
    
        }
