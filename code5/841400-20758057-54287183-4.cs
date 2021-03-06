    public class EmailIsUnique : ValidationAttribute
    {
        [Dependency]
        public IDataAccessHelper DataAccess {get;set;}
        private string _errorMessage = "An account with this {0} already exists";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            bool isValid = true;
            if(value == null) {
                isValid = false;
                _errorMessage = "{0} Cannot be empty";
            } else {
                string email = value.ToString();
                if (DataAccess.User.FindByEmail(email) != null)
                {
                    isValid = false;
                }
            }
            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult(String.Format(_errorMessage, validationContext.DisplayName));
        }
    }
