    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Helpers;
    
    namespace System.Web.Mvc
    {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateAntiForgeryTokenAttribute2 : FilterAttribute, IAuthorizationFilter
    {
        private string _salt;
        public ValidateAntiForgeryTokenAttribute2()
            : this(AntiForgery.Validate)
        {
        }
        internal ValidateAntiForgeryTokenAttribute2(Action validateAction)
        {
            Debug.Assert(validateAction != null);
            ValidateAction = validateAction;
        }
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "AdditionalDataProvider", Justification = "API name.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "AntiForgeryConfig", Justification = "API name.")]
        [Obsolete("The 'Salt' property is deprecated. To specify custom data to be embedded within the token, use the static AntiForgeryConfig.AdditionalDataProvider property.", error: true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Salt
        {
            get { return _salt; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    throw new NotSupportedException("The 'Salt' property is deprecated. To specify custom data to be embedded within the token, use the static AntiForgeryConfig.AdditionalDataProvider property.");
                }
                _salt = value;
            }
        }
        internal Action ValidateAction { get; private set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request.HttpMethod;
            if (request != "GET")
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
                ValidateAction();
            }
        }
    }
