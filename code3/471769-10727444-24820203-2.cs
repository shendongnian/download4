    internal class SettingsHolder
    {
        public SettingsHolder()
        {
            IsOriginalPropADefault = true;
        }
    
        private Class1 originalProp;
        public Class1 OriginalProp
        {
            get
            {
                return originalProp;
            }
            set
            {
                originalProp = value;
                IsOriginalPropADefault = false;
            }
        }
    
        public bool IsOriginalPropADefault { get; private set; }
    
    }
