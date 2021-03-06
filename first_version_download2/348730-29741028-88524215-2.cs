    public override void DoValidate(object objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Regex emailRegex = new Regex(IConnect.DataContract.WCFServiceResources.EmailRegex);
            Match match = emailRegex.Match((string)objectToValidate);
            if (!match.Success)
            {
                LogValidationResult(validationResults, string.Format(this.MessageTemplate, new object[] { objectToValidate }), currentTarget, key);
            }
        }
