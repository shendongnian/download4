    public class Sample : SampleA
    {
        private string _propertyA = "override";
        public override string PropertyA
        {
            get { return _propertyA; }
            set
            {
                // Maybe do some checks here
                _propertyA = value;
            }
        }
    }
