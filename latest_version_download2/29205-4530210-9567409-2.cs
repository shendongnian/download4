    public interface IValidatable
    {
        ValidationError[] Validate(Rulesets ruleSets);
    }
    
    public class View : IValidatable
    {
        public ValidationError[] Validate(Rulesets ruleSets)
        {
           // do validate
        }
    }
    
    public static class Validator
    {
        private static Rulesets _rulesets;
        static Validator()
        {
            // read rulesets
        }
        public static ValidationError[] Validate(object obj)
        {
            IValidatable validObj = obj as IValidatable;
            if (obj == null)
                // not validatable
                return new ValidationError[0];
            return validObj.Validate(_rulesets);
        }
    }
